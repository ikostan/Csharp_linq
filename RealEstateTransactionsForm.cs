using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading;

namespace ProjectTeam3
{
    public partial class RealEstateTransactionsForm : Form
    {
        /// <summary>
        /// Data fields and objects
        /// </summary>
        #region

        // Data lists
        private List<House> sortedTransactions;
        private List<House> selectedTransactions;
        //private List<House> unselectedTransactions;
        private SortedSet<string> cities, bedroomsNumber, bath, houseTypes;

        // File reader variables
        private OpenFileDialog fileDialog;
        private StreamReader streamReader;
        private string sourceFolderPath;
        private string sourceFilePath;

        // Filter variables
        private decimal minPrice, maxPrice;
        private double minSurfaceArea, maxSurfaceArea;

        //Errors and messages
        private readonly string digitsError = "\nOnly digits allowed!";
        private readonly string priceFilterError = "MIN price cannot be greater than MAX price value!";
        private readonly string surfaceFilterError = "MIN surface cannot be greater than MAX surface value!";
        private readonly string listIsEmpty = "The data list is empty. There is nothing to display.";

        WaitDialogForm waitDialogForm;
        //bool isFirstStart = true;  //Indicates if its first time open

        #endregion

        public RealEstateTransactionsForm()
        {

            //Show Please Wait Dialog                    
            //WaitDialogForm waitDialogForm = new WaitDialogForm();

            InitializeComponent();

            SetUpperDataGridView();     // Setting up columns for the "upperDataGridView"
            SetBottomDataGridView();    // Set up all columns for the "bottomDataGridView"
            CreateListObjects();        // Instantiates all list objects

            try
            {
                ClearListObjects();     // All list objects must be empty
                GetLocalFolderPath();   // Specify full path for the root project folder

                if (GetFilePath())      // Open a file in case user did not click on Cancel button
                {

                    streamReader = new StreamReader(sourceFilePath);

                    ReadAllData();
                    DisplayInitialData();  // Displays  data inside upper DataGridView

                    AddFilters();       // Adding all filters to the ListViews
                    CheckAllFilters();  // Set all filters as checked   

                    DisplaySelectedTransactions(); // Displays data inside bottom DataGridView
                    SetSelectedCount();         // Calculate number of records and displays it inside selectedAverageCountLabel
                    SetSelectedAveragePrice();  // Calculate average price and displays it inside averageSelectedPriceLabel

                }
                else // Show error in case user clicked on Cancel button
                {
                    MessageBox.Show(
                        "'Open File Dialog' has been canceled. No data will be shown.",
                        "ERROR",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "ERROR",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "ERROR",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                //Close StreamReader object if not null
                if (streamReader != null)
                {
                    streamReader.Close();
                }
            }
        }


        //All event handlers (including error handling and inner methods)
        #region


        /// <summary>
        /// On Form Load event handler.
        /// Waiting until form is loaded and then attach event handlers to all relevant controls.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RealEstateTransactionsForm_Load(object sender, EventArgs e)
        {
            if (((RealEstateTransactionsForm)Application.OpenForms["RealEstateTransactionsForm"]).Visible == true)
            {
                RegisterEvents();
            }
        }

        /// <summary>
        /// Attach event handlers to all relevant controls.
        /// </summary>
        private void RegisterEvents()
        {
            this.citiesListView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.citiesListView__ItemChecked);
            this.bedroomsListView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.bedroomsListView__ItemChecked);
            this.bathsListView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.bathsListView__ItemChecked);
            this.houseTypesListView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.houseTypesListView_ItemChecked);
        }

        /// <summary>
        /// Detach event handlers to all relevant controls.
        /// </summary>
        private void UnregisterEvents()
        {
            this.citiesListView.ItemChecked -= new System.Windows.Forms.ItemCheckedEventHandler(this.citiesListView__ItemChecked);
            this.bedroomsListView.ItemChecked -= new System.Windows.Forms.ItemCheckedEventHandler(this.bedroomsListView__ItemChecked);
            this.bathsListView.ItemChecked -= new System.Windows.Forms.ItemCheckedEventHandler(this.bathsListView__ItemChecked);
            this.houseTypesListView.ItemChecked -= new System.Windows.Forms.ItemCheckedEventHandler(this.houseTypesListView_ItemChecked);
        }

        /// <summary>
        /// Event handler for houseTypesListView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void houseTypesListView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(
                   $"{System.Reflection.MethodBase.GetCurrentMethod().Name} method called"); //Debug only

            if (e.Item.Checked)
            {
                houseTypes.Add(e.Item.Text);
            }
            else if (!e.Item.Checked)
            {
                houseTypes.Remove(e.Item.Text);
            }

            DisplaySelectedResults();
        }

        /// <summary>
        /// Event Handler to  bathsListView, this method moves unselected items 
        /// into unselected items list and vise versa. At the end another 3 methods will be activated:
        /// DisplaySelectedTransactions()
        /// SetSelectedCount();         
        /// SetSelectedAveragePrice();
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bathsListView__ItemChecked(object sender, ItemCheckedEventArgs e)
        {

            System.Diagnostics.Debug.WriteLine($"{System.Reflection.MethodBase.GetCurrentMethod().Name} method called"); //Debug only

            /*
            System.Diagnostics.Debug.WriteLine(
                    $"BEFORE => selectedTransactions count: {selectedTransactions.Count} out of {sortedTransactions.Count}");//Debug only
                                                                                                                             //unselectedTransactions count: {unselectedTransactions.Count}, TOTAL: {selectedTransactions.Count + unselectedTransactions.Count}"); //Debug only
            System.Diagnostics.Debug.WriteLine($"{e.Item.Text}: {e.Item.Checked}"); //Debug only

            System.Diagnostics.Debug.WriteLine($"BEFORE => bath filter count: {bath.Count}"); //Debug only
            */


            if (e.Item.Checked)
            {
                bath.Add(e.Item.Text);
                // System.Diagnostics.Debug.WriteLine($"Item added: {e.Item.Text}"); //Debug only
            }
            else if (!e.Item.Checked)
            {
                bath.Remove(e.Item.Text);
                // System.Diagnostics.Debug.WriteLine($"Item removed: {e.Item.Text}"); //Debug only
            }

            // System.Diagnostics.Debug.WriteLine($"AFTER => bath filter count: {bath.Count}"); //Debug only

            DisplaySelectedResults();

        }

        /// <summary>
        /// Represents collections of 3 methods that are needed to be activated 
        /// after event handler is finished its work
        /// </summary>
        private void DisplaySelectedResults()
        {

            //Show Wait Dialog
            WaitDialogForm waitDialogForm = new WaitDialogForm();
            waitDialogForm.Show();
            waitDialogForm.Refresh(); //Otherwise screen fails to refresh splash

            // Delete old data:
            // When a ListView item is cleared, the selected transactions 
            // in the DataGridViewControl change IMMEDIATELY.
            bottomDataGridView.Rows.Clear();
            bottomDataGridView.DataSource = null;

            // Repopulate all selected transactions after sorting procedure
            DisplaySelectedTransactions();

            waitDialogForm.Refresh(); //Otherwise screen fails to refresh splash

            // Under both DataGridView controls, Count and Average Price must be reported (use LINQ).

            SetSelectedCount();         // Calculate number of records and displays it inside selectedAverageCountLabel

            SetSelectedAveragePrice();  // Calculate average price and displays it inside averageSelectedPriceLabel

            waitDialogForm.Close(); //Close Wait Dialog

        }

        /// <summary>
        /// Refresh WaitDialog, otherwise screen fails to refresh splash.
        /// </summary>
        private void RefreshWaitDialog()
        {
            if (waitDialogForm != null)
            {
                waitDialogForm.Refresh(); //Otherwise screen fails to refresh splash
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bedroomsListView__ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(
                $"{System.Reflection.MethodBase.GetCurrentMethod().Name} method called"); //Debug only 

            /*
            System.Diagnostics.Debug.WriteLine(
                    $"BEFORE => selectedTransactions count: {selectedTransactions.Count} out of {sortedTransactions.Count}");//Debug only

            System.Diagnostics.Debug.WriteLine($"{e.Item.Text}: {e.Item.Checked}"); //Debug only
            */

            if (e.Item.Checked)
            {
                bedroomsNumber.Add(e.Item.Text);
            }
            else if (!e.Item.Checked)
            {
                bedroomsNumber.Remove(e.Item.Text);
            }

            DisplaySelectedResults();

        }

        /// <summary>
        /// Event handler for Cities filter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void citiesListView__ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(
                $"{System.Reflection.MethodBase.GetCurrentMethod().Name} method called"); //Debug only

            if (e.Item.Checked)
            {
                cities.Add(e.Item.Text);
            }
            else if (!e.Item.Checked)
            {
                cities.Remove(e.Item.Text);
            }

            DisplaySelectedResults();
        }


        //Inner methods
        #region


        /// <summary>
        /// Extract MIN price
        /// </summary>
        private void GetMinPrice()
        {
            minPriceTextBox.BackColor = System.Drawing.SystemColors.Highlight;
            minPriceTextBox.Focus();
            minPrice = decimal.Parse(minPriceTextBox.Text.ToString().Trim());
            minPriceTextBox.BackColor = System.Drawing.SystemColors.Window;
        }

        /// <summary>
        /// Extract MAX price
        /// </summary>
        private void GetMaxPrice()
        {
            maxPriceTextBox.BackColor = System.Drawing.SystemColors.Highlight;
            maxPriceTextBox.Focus();
            maxPrice = decimal.Parse(maxPriceTextBox.Text.ToString().Trim());
            maxPriceTextBox.BackColor = System.Drawing.SystemColors.Window;
        }

        /// <summary>
        /// Compare MIN vs MAX prices and show an error in case MIN > MAX
        /// </summary>
        private void ComparePrices()
        {
            if (minPrice > maxPrice)
            {
                minPriceTextBox.BackColor = System.Drawing.SystemColors.Highlight;
                minPriceTextBox.Focus();
                throw new Exception(priceFilterError);
            }
            else
            {
                priceCheckBox.Focus();
            }
        }

        /// <summary>
        /// Extract MIN surface value
        /// </summary>
        private void GetMinSurface()
        {
            //System.Diagnostics.Debug.WriteLine($"{System.Reflection.MethodBase.GetCurrentMethod().Name} method called"); //Debug only
            minSurfaceTextBox.BackColor = System.Drawing.SystemColors.Highlight;
            minSurfaceTextBox.Focus();
            minSurfaceArea = double.Parse(minSurfaceTextBox.Text.ToString().Trim());
            minSurfaceTextBox.BackColor = System.Drawing.SystemColors.Window;
        }

        /// <summary>
        /// Extract Max surface area
        /// </summary>
        private void GetMaxSurface()
        {
            //System.Diagnostics.Debug.WriteLine($"{System.Reflection.MethodBase.GetCurrentMethod().Name} method called"); //Debug only

            maxSurfaceTextBox.BackColor = System.Drawing.SystemColors.Highlight;
            maxSurfaceTextBox.Focus();
            maxSurfaceArea = double.Parse(maxSurfaceTextBox.Text.ToString().Trim());
            maxSurfaceTextBox.BackColor = System.Drawing.SystemColors.Window;
        }

        /// <summary>
        /// Compare MIN vs MAX surface area and show an error in case MIN > MAX
        /// </summary>
        private void CompareSurfaces()
        {
            //System.Diagnostics.Debug.WriteLine($"{System.Reflection.MethodBase.GetCurrentMethod().Name} method called"); //Debug only

            if (minSurfaceArea > maxSurfaceArea)
            {
                minSurfaceTextBox.BackColor = System.Drawing.SystemColors.Highlight;
                minSurfaceTextBox.Focus();
                throw new Exception(surfaceFilterError);
            }
            else
            {
                surfaceCheckBox.Focus();
            }
        }


        #endregion

        //Event + Error handling
        /// <summary>
        /// More importantly, exceptions for Price and SurfaceArea must be handled. For example, if one types in a
        /// letter instead of a number and a Check-box is set, an exception should be thrown, and the Check-box
        /// should be cleared.The TextBoxes can remain the same so the user can edit them and correct the error.
        /// </summary>
        #region

        /// <summary>
        /// If the user checks the Search on Price and/or Search on Surface Area boxes, then the filter must further
        /// refine the result, only selected records that fall between the max and min for each.
        /// </summary>
        private void FilterPrice()
        {
            //Cursor.Current = Cursors.WaitCursor;

            RefreshWaitDialog();

            try
            {
                if (priceCheckBox.Checked)
                {
                    GetMinPrice();      //Extract MIX price
                    GetMaxPrice();      //Extract MAX price
                    ComparePrices();    //Compare MIN vs MAX and show an error in case MIN > MAX
                }

                //TODO: update bottomDataGridView items according to user input
                DisplaySelectedResults();
            }
            catch (Exception ex)
            {
                priceCheckBox.Checked = false;

                if (!ex.Message.ToString().Equals(priceFilterError))
                {
                    MessageBox.Show(
                        ex.Message + digitsError,
                        "ERROR",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else //Do not add 'digitsError' message in case it is 'MIN > MAX' error
                {
                    MessageBox.Show(
                        ex.Message,
                        "ERROR",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }

            RefreshWaitDialog();
            //Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Extract MIN and MAX filter prices and compare between them (includes error handler)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void priceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine($"{System.Reflection.MethodBase.GetCurrentMethod().Name} method called"); //Debug only
            Cursor.Current = Cursors.WaitCursor;
            FilterPrice();
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// TextChanged event handler for maxPriceTextBox
        /// If the CheckBoxes are checked, and the max or min TextBox is changed, 
        /// the result due to the change in the TextBoxes
        /// should be shown immediately.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void minPriceTextBox_TextChanged(object sender, EventArgs e)
        {
            // System.Diagnostics.Debug.WriteLine($"{System.Reflection.MethodBase.GetCurrentMethod().Name} method called"); //Debug only

            if (priceCheckBox.Checked)
            {
                Cursor.Current = Cursors.WaitCursor;
                FilterPrice();
                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
        /// TextChanged event handler for maxPriceTextBox
        /// If the CheckBoxes are checked, and the max or min TextBox is changed, 
        /// the result due to the change in the TextBoxes
        /// should be shown immediately.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void maxPriceTextBox_TextChanged(object sender, EventArgs e)
        {
            // System.Diagnostics.Debug.WriteLine($"{System.Reflection.MethodBase.GetCurrentMethod().Name} method called"); //Debug only

            if (priceCheckBox.Checked)
            {
                Cursor.Current = Cursors.WaitCursor;
                FilterPrice();
                Cursor.Current = Cursors.Default;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        private void FilterSurface()
        {
            //Cursor.Current = Cursors.WaitCursor;
            RefreshWaitDialog();

            try
            {
                if (surfaceCheckBox.Checked)
                {
                    GetMinSurface();    //Extract MIN surface
                    GetMaxSurface();    //Extract MAX surface
                    CompareSurfaces();  //Compare MIN vs MAX and show an error in case MIN > MAX
                }

                //TODO: update bottomDataGridView items according to user input
                DisplaySelectedResults();
            }
            catch (Exception ex)
            {
                surfaceCheckBox.Checked = false;

                if (!ex.Message.ToString().Equals(surfaceFilterError))
                {
                    MessageBox.Show(
                        ex.Message + digitsError,
                        "ERROR",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else //Do not add 'digitsError' message in case it is 'MIN > MAX' error
                {
                    MessageBox.Show(
                        ex.Message,
                        "ERROR",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }

            RefreshWaitDialog();
            //Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Extract MIN and MAX filter surfaces and compare between them (includes error handler)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void surfaceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine($"{System.Reflection.MethodBase.GetCurrentMethod().Name} method called"); //Debug only
            Cursor.Current = Cursors.WaitCursor;
            FilterSurface();
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// TextChanged event handler for minSurfaceTextBox
        /// If the CheckBoxes are checked, and the max or min TextBox is changed, 
        /// the result due to the change in the TextBoxes
        /// should be shown immediately.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void minSurfaceTextBox_TextChanged(object sender, EventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine($"{System.Reflection.MethodBase.GetCurrentMethod().Name} method called"); //Debug only

            if (surfaceCheckBox.Checked)
            {
                Cursor.Current = Cursors.WaitCursor;
                FilterSurface();
                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
        /// TextChanged event handler for maxSurfaceTextBox       
        /// If the CheckBoxes are checked, and the max or min TextBox is changed, 
        /// the result due to the change in the TextBoxes
        /// should be shown immediately.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void maxSurfaceTextBox_TextChanged(object sender, EventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine($"{System.Reflection.MethodBase.GetCurrentMethod().Name} method called"); //Debug only

            if (surfaceCheckBox.Checked)
            {
                Cursor.Current = Cursors.WaitCursor;
                FilterSurface();
                Cursor.Current = Cursors.Default;
            }
        }

        #endregion


        /// <summary>
        /// The Reset Filters button resets the form to the initial state when clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void resetFiltersButton_Click(object sender, EventArgs e)
        {
            UnregisterEvents();

            //Cursor.Current = Cursors.WaitCursor;
            RefreshWaitDialog();

            System.Diagnostics.Debug.WriteLine($"{System.Reflection.MethodBase.GetCurrentMethod().Name} method called"); //Debug only

            //De-select price and surface filters
            priceCheckBox.Checked = false;
            surfaceCheckBox.Checked = false;

            //Reset MIN price TextBox and CheckBox
            minPriceTextBox.Text = "";
            minPriceTextBox.BackColor = System.Drawing.SystemColors.Window;

            maxPriceTextBox.Text = "";
            maxPriceTextBox.BackColor = System.Drawing.SystemColors.Window;

            //Reset MAX price TextBox and CheckBox
            maxSurfaceTextBox.Text = "";
            maxSurfaceTextBox.BackColor = System.Drawing.SystemColors.Window;

            minSurfaceTextBox.Text = "";
            minSurfaceTextBox.BackColor = System.Drawing.SystemColors.Window;

            CheckAllFilters(); //Go over the filters and check all check-boxes

            DisplaySelectedResults();

            RefreshWaitDialog();
            //Cursor.Current = Cursors.Default;

            RegisterEvents();
        }


        #endregion


        //ListViews set up (including filters) 
        #region


        /// <summary>
        /// Read the source file and display sorted data including filters
        /// </summary>
        private void ReadAllData()
        {
            Cursor.Current = Cursors.WaitCursor;

            // Show Wait Dialog
            //WaitDialogForm waitDialogForm = new WaitDialogForm();
            //waitDialogForm.Show();
            //waitDialogForm.Refresh(); //Otherwise screen fails to refresh splash

            List<House> unsortedTransactions = new List<House>();
            ReadSourceFile(unsortedTransactions);   // Read source file and add data to the unsortedTransactions list

            sortedTransactions.AddRange(SortDataList(unsortedTransactions));     // The data should be sorted by City, HouseType, then Price
            selectedTransactions.AddRange(sortedTransactions); // Add all sorted transactions to UNSELECTED list

            //waitDialogForm.Close(); //Close Wait Dialog
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Check all check-boxes inside filters ListView
        /// </summary>
        private void CheckAllFilters()
        {
            RefreshWaitDialog();

            ResetCitiesFilter();
            ResetBedroomsFilter();
            ResetBathsFilter();
            ResetHouseTypesFilter();

            RefreshWaitDialog();
        }

        /// <summary>
        /// Reset Cities Filter
        /// </summary>
        private void ResetCitiesFilter()
        {
            foreach (ListViewItem item in citiesListView.Items)
            {
                cities.Add(item.Text.ToString()); //Add item back to the cities list

                if (item.Checked == false)
                {
                    item.Checked = true;
                }
            }
        }

        /// <summary>
        /// Reset Bedrooms Filter
        /// </summary>
        private void ResetBedroomsFilter()
        {
            foreach (ListViewItem item in bedroomsListView.Items)
            {
                bedroomsNumber.Add(item.Text.ToString()); //Add item back to the list of bedroomsNumber

                if (item.Checked == false)
                {
                    item.Checked = true;
                }
            }
        }

        /// <summary>
        /// Reset Baths Filter
        /// </summary>
        private void ResetBathsFilter()
        {
            foreach (ListViewItem item in bathsListView.Items)
            {
                bath.Add(item.Text.ToString()); //Add item back to the bath list

                if (item.Checked == false)
                {
                    item.Checked = true;
                }
            }
        }

        /// <summary>
        /// Reset HouseTypes Filter
        /// </summary>
        private void ResetHouseTypesFilter()
        {
            foreach (ListViewItem item in houseTypesListView.Items)
            {
                houseTypes.Add(item.Text.ToString()); //Add item back to the houseTypes list

                if (item.Checked == false)
                {
                    item.Checked = true;
                }
            }
        }

        /// <summary>
        /// Add items into ListView object
        /// </summary>
        /// <param name="listView"></param>
        /// <param name="list"></param>
        /// <param name="width"></param>
        private void SetFiltersListView(ListView listView, SortedSet<string> list, int width)
        {
            listView.CheckBoxes = true;

            // Making List view scroll in vertical direction
            listView.Scrollable = true;
            listView.View = View.Details;

            // Members are added one at a time, so call BeginUpdate to ensure 
            // the list is painted only once, rather than as each list item is added.
            listView.BeginUpdate();

            foreach (var item in list)
            {
                listView.Items.Add(new ListViewItem(item));
            }

            //Call EndUpdate when you finish adding items to the ListView.
            listView.EndUpdate();
        }

        /// <summary>
        /// Create unique lists of parameters
        /// </summary>
        /// <param name="data"></param>
        private void SetUniqueParameters(string[] data)
        {
            cities.Add(data[1]);
            bedroomsNumber.Add(data[2]);
            bath.Add(data[3]);
            houseTypes.Add(data[5]);
        }

        /// <summary>
        /// Instantiates all list objects
        /// </summary>
        private void CreateListObjects()
        {
            cities = new SortedSet<string>();
            bedroomsNumber = new SortedSet<string>();
            bath = new SortedSet<string>();
            houseTypes = new SortedSet<string>();
            sortedTransactions = new List<House>();
            selectedTransactions = new List<House>();
            //unselectedTransactions = new List<House>();
            //unsortedTransactions = new List<House>();
        }

        /// <summary>
        /// Clear all list objects
        /// </summary>
        private void ClearListObjects()
        {
            cities.Clear();
            bedroomsNumber.Clear();
            bath.Clear();
            houseTypes.Clear();
            selectedTransactions.Clear();
            sortedTransactions.Clear();
            //unselectedTransactions.Clear();
            //unsortedTransactions.Clear();
        }

        /// <summary>
        /// Adding all filters to the ListViews
        /// </summary>
        private void AddFilters()
        {
            SetFiltersListView(citiesListView, cities, 170);
            SetFiltersListView(bedroomsListView, bedroomsNumber, 80);
            SetFiltersListView(bathsListView, bath, 80);
            SetFiltersListView(houseTypesListView, houseTypes, 110);
        }

        #endregion


        //Reads source file
        #region


        /// <summary>
        /// Get user action from OpenFileDialog including source file path
        /// </summary>
        /// <returns></returns>
        private bool GetFilePath()
        {
            fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = sourceFolderPath; // Set initial directory

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                sourceFilePath = fileDialog.FileName;
                //System.Diagnostics.Debug.WriteLine($"sourceFilePath: {sourceFilePath}"); // For debug only
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Specifies full path for the source folder (project directory)
        /// </summary>
        private void GetLocalFolderPath()
        {
            sourceFolderPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            //System.Diagnostics.Debug.WriteLine($"sourceFolderPath: {sourceFolderPath}"); // For debug only
        }

        /// <summary>
        /// Read source file and add data to the unsortedTransactions list
        /// </summary>
        private void ReadSourceFile(List<House> unsortedTransactions)
        {
            unsortedTransactions.Clear(); //Clear the list from the old data

            int index = 0;

            while (!streamReader.EndOfStream)
            {
                string line = streamReader.ReadLine().ToString().Trim();
                string[] data = line.Split(',').Select((p) => p.Trim()).ToArray();
                //System.Diagnostics.Debug.WriteLine($"line: {line}"); // For debug only

                if (index != 0) //Skip first line
                {
                    //Add House object into unsorted List
                    unsortedTransactions.Add(new House(data));

                    //Create unique lists of parameters
                    SetUniqueParameters(data);
                }

                index++;
            }
        }

        /// <summary>
        /// The data should by sorted by City, HouseType, then Price(use LINQ).
        /// </summary>
        private List<House> SortDataList(List<House> unsorted)
        {
            // Using IComparer Interface:
            // unsortedTransactions.Sort(new CompareByCity());
            // unsortedTransactions.Sort(new CompareByHouseType());
            // unsortedTransactions.Sort(new CompareByPrice());

            // Using LINQ:
            var sortedList =
                unsorted
                .OrderBy((p) => p.Price)
                .OrderBy((p) => p.HouseType)
                .OrderBy((p) => p.City)
                ;

            return sortedList.ToList();
        }


        #endregion


        //Displays the data inside upper DataGridView
        #region

        /// <summary>
        /// Displays all the data inside upper DataGridView
        /// </summary>
        private void DisplayInitialData()
        {
            upperDataGridView.Rows.Clear(); //Clear all rows (remove old data)
                                            //upperDataGridView.Refresh();

            RefreshWaitDialog();

            //Show Wait Dialog
            //WaitDialogForm waitDialogForm = new WaitDialogForm();
            //waitDialogForm.Show();
            //waitDialogForm.Refresh(); //Otherwise screen fails to refresh splash

            if (sortedTransactions.Count() > 0)
            {
                for (int i = 0; i < sortedTransactions.Count; i++)
                {
                    upperDataGridView.Rows.Add(
                        sortedTransactions[i].Address,
                        sortedTransactions[i].City,
                        sortedTransactions[i].Bedrooms,
                        sortedTransactions[i].Bathrooms,
                        sortedTransactions[i].SurfaceArea,
                        sortedTransactions[i].HouseType,
                        sortedTransactions[i].Price);
                }

                upperDataGridView.Refresh();

                // Under both DataGridView controls, Count and Average Price must be reported (use LINQ).

                SetCount();                 // Calculate number of records and displays it inside countLabel
                SetAveragePrice();          // Calculate average price and displays it inside averagePriceLabel

            }
            else
            {
                MessageBox.Show(
                   listIsEmpty,
                   "All Transactions Information Dialog",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
            }

            RefreshWaitDialog();

            //waitDialogForm.Close(); //Close Wait Dialog
        }

        /// <summary>
        /// Calculate number of records and displays it inside countLabel
        /// Under both DataGridView controls, Count and Average Price must be reported (use LINQ).
        /// </summary>
        private void SetCount()
        {
            //countLabel.Text = unsortedTransactions.Count().ToString(); //Old method
            var totalCount =
                sortedTransactions
                .Count()
                ;

            countLabel.Text = totalCount.ToString("N0");
        }

        /// <summary>
        /// Calculate average price and displays it inside averagePriceLabel
        /// Under both DataGridView controls, Count and Average Price must be reported (use LINQ).
        /// </summary>
        private void SetAveragePrice()
        {
            decimal averagePrice = 0.0M;

            if (sortedTransactions.Count > 0)
            {
                averagePrice =
                    sortedTransactions
                    .Average((p) => p.Price)
                    ;
            }


            //System.Diagnostics.Debug.WriteLine($"averagePrice: {averagePrice}"); // For debug only

            averagePriceLabel.Text = string.Format($"{averagePrice:C}");
        }

        /// <summary>
        /// The bottom control always displays the results of the filters that are set. 
        /// Note that it has the same structure as the top control, 
        /// and should be sorted by City, HouseType, and Price(use LINQ).
        /// </summary>
        private void DisplaySelectedTransactions()
        {
            //System.Diagnostics.Debug.WriteLine("DisplaySelectedTransactions method is activated"); //Debug only

            // LINQ MUST be used to generate the result to display.
            // selected transactions result is provided where the selected Cities AND
            // selected Bedrooms AND selected Bathrooms AND selected HouseTypes match the original data records

            IEnumerable<House> selected;

            //Filter the results by: cities, bedrooms, bath, house type
            IEnumerable<House> selectedList =
                sortedTransactions
                .Where((p) =>
                    cities.Contains(p.City) &&
                    bedroomsNumber.Contains(p.Bedrooms.ToString()) &&
                    bath.Contains(p.Bathrooms.ToString()) &&
                    houseTypes.Contains(p.HouseType)
                )
                ;

            // Price and Surface_Area filters:
            // Filter variables: minPrice, maxPrice, minSurfaceArea, maxSurfaceArea;
            if (priceCheckBox.Checked && surfaceCheckBox.Checked)
            {
                selected =
                    selectedList
                    .Where((p) =>
                        p.Price <= maxPrice &&
                        p.Price >= minPrice &&
                        p.SurfaceArea <= maxSurfaceArea &&
                        p.SurfaceArea >= minSurfaceArea
                    )
                    ;
            }
            else if (priceCheckBox.Checked) // Filter variables: minPrice, maxPrice;
            {
                selected =
                    selectedList
                    .Where((p) =>
                        p.Price <= maxPrice &&
                        p.Price >= minPrice
                    )
                    ;
            }
            else if (surfaceCheckBox.Checked) // Filter variables: minSurfaceArea, maxSurfaceArea;
            {
                selected =
                    selectedList
                    .Where((p) =>
                        p.SurfaceArea <= maxSurfaceArea &&
                        p.SurfaceArea >= minSurfaceArea
                    )
                    ;
            }
            else
            {
                selected = selectedList;
            }


            // Results should be sorted by City, HouseType, and Price (use LINQ):
            selectedTransactions.Clear();
            selectedTransactions.AddRange(SortDataList(selected.ToList()));                                                                                                                   //unselectedTransactions count: {unselectedTransactions.Count}, TOTAL: {selectedTransactions.Count + unselectedTransactions.Count}"); //Debug only

            // Populate the results into DataGridView controls:
            if (selectedTransactions.Count() > 0)
            {
                for (int i = 0; i < selectedTransactions.Count; i++)
                {
                    bottomDataGridView.Rows.Add(
                        selectedTransactions[i].Address,
                        selectedTransactions[i].City,
                        selectedTransactions[i].Bedrooms,
                        selectedTransactions[i].Bathrooms,
                        selectedTransactions[i].SurfaceArea,
                        selectedTransactions[i].HouseType,
                        selectedTransactions[i].Price
                        );
                }

                bottomDataGridView.Refresh();
            }
            else
            {
                MessageBox.Show(
                  listIsEmpty,
                  "Selected Transactions Information Dialog",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
            }

            //System.Diagnostics.Debug.WriteLine(
            //    $"\ncities: {cities.Count} \nbedrooms: {bedroomsNumber.Count} \nbath: {bath.Count} \nhouse types: {houseTypes.Count}"); //Debug only

        }

        /// <summary>
        /// Calculate number of records and displays it inside selectedAverageCountLabel
        /// Under both DataGridView controls, Count and Average Price must be reported (use LINQ).
        /// </summary>
        private void SetSelectedCount()
        {
            //System.Diagnostics.Debug.WriteLine($"{System.Reflection.MethodBase.GetCurrentMethod().Name} method called"); //Debug only

            //Count total items inside selected items list
            var totalCount =
               selectedTransactions
               .Count()
               ;

            int totalRows = (int)bottomDataGridView.Rows.Count; //Count number of rows inside selected items DataGridView

            //Internal Validation: totalCount must be equal to totalRows
            if ((int)totalCount != totalRows)
            {
                throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + ". Internal Validation Failed: totalCount must be equal to totalRows.");
            }
            else
            {
                selectedAverageCountLabel.Text = totalCount.ToString("N0"); //Display the result
            }
        }

        /// <summary>
        /// Calculate average price and displays it inside averageSelectedPriceLabel
        /// Under both DataGridView controls, Count and Average Price must be reported (use LINQ).
        /// </summary>
        private void SetSelectedAveragePrice()
        {
            //System.Diagnostics.Debug.WriteLine($"{System.Reflection.MethodBase.GetCurrentMethod().Name} method called"); //Debug only
            decimal averagePrice = 0.0M;

            if (selectedTransactions.Count > 0)
            {
                averagePrice =
                                selectedTransactions
                                .Average((p) => p.Price)
                                ;
            }

            averageSelectedPriceLabel.Text = string.Format($"{averagePrice:C}");
        }


        #endregion


        //Setting up upper DataGridView columns
        #region
        /// <summary>
        /// Set up all columns for the "upperDataGridView"
        /// </summary>
        private void SetUpperDataGridView()
        {
            SetAddressColumn();
            SetCityColumn();
            SetBedroomsColumn();
            SetBathroomsColumn();
            SetSurfaceAreaColumn();
            SetHouseTypeColumn();
            SetPriceColumn();

            //this.upperDataGridView.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
        }

        /// <summary>
        /// Set up Address column for the "upperDataGridView"
        /// </summary>
        private void SetAddressColumn()
        {
            this.address.HeaderText = "Address";
            this.address.ToolTipText = "Address";
            this.address.Width = 190;
            //this.address.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
        }

        /// <summary>
        /// Set up City column for the "upperDataGridView"
        /// </summary>
        private void SetCityColumn()
        {
            this.city.HeaderText = "City";
            this.city.ToolTipText = "City";
            this.city.Width = 120;
            //this.city.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
        }

        /// <summary>
        /// Set up Bedrooms column for the "upperDataGridView"
        /// </summary>
        private void SetBedroomsColumn()
        {
            this.bedrooms.HeaderText = "Bedrooms";
            this.bedrooms.ToolTipText = "Bedrooms";
            this.bedrooms.Width = 60;
            //this.bedrooms.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
        }

        /// <summary>
        /// Set up Bathrooms column for the "upperDataGridView"
        /// </summary>
        private void SetBathroomsColumn()
        {
            this.bathrooms.HeaderText = "Bathrooms";
            this.bathrooms.ToolTipText = "Bathrooms";
            this.bathrooms.Width = 60;
            //this.bathrooms.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
        }

        /// <summary>
        /// Set up SurfaceArea column for the "upperDataGridView"
        /// </summary>
        private void SetSurfaceAreaColumn()
        {
            this.surfaceArea.HeaderText = "SurfaceArea";
            this.surfaceArea.ToolTipText = "SurfaceArea";
            this.surfaceArea.Width = 90;
            //this.surfaceArea.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
        }

        /// <summary>
        /// Set up HouseType column for the "upperDataGridView"
        /// </summary>
        private void SetHouseTypeColumn()
        {
            this.houseType.HeaderText = "HouseType";
            this.houseType.ToolTipText = "HouseType";
            this.houseType.Width = 80;
            //this.houseType.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
        }

        /// <summary>
        /// Set up Price column for the "upperDataGridView"
        /// </summary>
        private void SetPriceColumn()
        {
            this.price.HeaderText = "Price";
            this.price.ToolTipText = "Price";
            this.price.Width = 70;
            //this.price.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        }
        #endregion


        //Setting up bottom DataGridView columns
        #region
        /// <summary>
        /// Set up all columns for the "bottomDataGridView"
        /// </summary>
        private void SetBottomDataGridView()
        {
            SetSelectedAddressColumn();
            SetSelectedCityColumn();
            SetSelectedBedroomsColumn();
            SetSelectedBathroomsColumn();
            SetSelectedSurfaceAreaColumn();
            SetSelectedHouseTypeColumn();
            SetSelectedPriceColumn();

            //this.bottomDataGridView.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
        }

        /// <summary>
        /// Set up Address column for the "bottomDataGridView"
        /// </summary>
        private void SetSelectedAddressColumn()
        {
            this.selectedAddress.HeaderText = "Address";
            this.selectedAddress.ToolTipText = "Address";
            this.selectedAddress.Width = 190;
            //this.selectedAddress.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
        }

        /// <summary>
        /// Set up City column for the "bottomDataGridView"
        /// </summary>
        private void SetSelectedCityColumn()
        {
            this.selectedCity.HeaderText = "City";
            this.selectedCity.ToolTipText = "City";
            this.selectedCity.Width = 120;
            //this.selectedCity.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
        }

        /// <summary>
        /// Set up Bedrooms column for the "bottomDataGridView"
        /// </summary>
        private void SetSelectedBedroomsColumn()
        {
            this.selectedBedrooms.HeaderText = "Bedrooms";
            this.selectedBedrooms.ToolTipText = "Bedrooms";
            this.selectedBedrooms.Width = 60;
            //this.selectedBedrooms.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
        }

        /// <summary>
        /// Set up Bathrooms column for the "bottomDataGridView"
        /// </summary>
        private void SetSelectedBathroomsColumn()
        {
            this.selectedBathrooms.HeaderText = "Bathrooms";
            this.selectedBathrooms.ToolTipText = "Bathrooms";
            this.selectedBathrooms.Width = 60;
            //this.selectedBathrooms.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
        }

        /// <summary>
        /// Set up SurfaceArea column for the "bottomDataGridView"
        /// </summary>
        private void SetSelectedSurfaceAreaColumn()
        {
            this.selectedSurfaceArea.HeaderText = "SurfaceArea";
            this.selectedSurfaceArea.ToolTipText = "SurfaceArea";
            this.selectedSurfaceArea.Width = 90;
            //this.selectedSurfaceArea.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
        }

        /// <summary>
        /// Set up HouseType column for the "bottomDataGridView"
        /// </summary>
        private void SetSelectedHouseTypeColumn()
        {
            this.selectedHouseType.HeaderText = "HouseType";
            this.selectedHouseType.ToolTipText = "HouseType";
            this.selectedHouseType.Width = 80;
            //this.selectedHouseType.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
        }

        /// <summary>
        /// Set up Price column for the "bottomDataGridView"
        /// </summary>
        private void SetSelectedPriceColumn()
        {
            this.selectedPrice.HeaderText = "Price";
            this.selectedPrice.ToolTipText = "Price";
            this.selectedPrice.Width = 70;
            //this.selectedPrice.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        }
        #endregion


    }
}
