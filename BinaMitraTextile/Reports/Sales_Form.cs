using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Windows.Forms.DataVisualization.Charting;

namespace BinaMitraTextile.Reports
{
    public partial class Sales_Form : Form
    {
        public Sales_Form()
        {
            InitializeComponent();

            setupControls();
        }

        private void setupControls()
        {
            Settings.setGeneralSettings(this);

            Customer.populateDropDownList(cbExcludeCustomers, false, false);
            LengthUnit.populateInputControlCheckedListBox(iclb_LengthUnits, false);
            FabricColor.populateInputControlCheckedListBox(iclb_Colors, false);
            Grade.populateInputControlCheckedListBox(iclb_Grades, false);
            ProductWidth.populateInputControlCheckedListBox(iclb_ProductWidths, false);
            ProductStoreName.populateInputControlCheckedListBox(iclb_ProductStoreNames, false);
            Customer.populateInputControlCheckedListBox(iclb_Customers, false);
            
            gridSummaryByMonth.AutoGenerateColumns = false;
            gridSummaryByMonth.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            col_gridsummary_month.DataPropertyName = Sale.COL_CHART_SALEYEARMONTH;
            col_gridsummary_qty.DataPropertyName = Sale.COL_CHART_QTY;
            col_gridsummary_sales.DataPropertyName = Sale.COL_CHART_TOTAL;
            col_gridsummary_profit.DataPropertyName = Sale.COL_CHART_PROFIT;
            col_gridsummary_percentage.DataPropertyName = Sale.COL_CHART_PERCENT;

            gridSummaryByCustomers.AutoGenerateColumns = false;
            gridSummaryByCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            col_dgvSummaryByCustomers_customer_id.DataPropertyName = Sale.COL_CHARTSUMMARYBYCUSTOMERS_CUSTOMERID;
            col_dgvSummaryByCustomers_customer_name.DataPropertyName = Sale.COL_CHARTSUMMARYBYCUSTOMERS_CUSTOMERNAME;
            col_dgvSummaryByCustomers_sale_length.DataPropertyName = Sale.COL_CHARTSUMMARYBYCUSTOMERS_SALEQTY;
            col_dgvSummaryByCustomers_sale_amount.DataPropertyName = Sale.COL_CHARTSUMMARYBYCUSTOMERS_SALEAMOUNT;
            col_dgvSummaryByCustomers_profit_amount.DataPropertyName = Sale.COL_CHARTSUMMARYBYCUSTOMERS_PROFITAMOUNT;
            col_dgvSummaryByCustomers_profit_percent.DataPropertyName = Sale.COL_CHARTSUMMARYBYCUSTOMERS_PROFITPERCENT;

            dgvDetailBySales.AutoGenerateColumns = false;
            Tools.clearWhenSelected(dgvDetailBySales);
            col_griddetail_saleid.DataPropertyName = Sale.COL_CHARTDETAILBYSALES_SALEID;
            col_griddetail_timestamp.DataPropertyName = Sale.COL_CHARTDETAILBYSALES_TIMESTAMP;
            col_griddetail_barcode.DataPropertyName = Sale.COL_CHARTDETAILBYSALES_SALEBARCODE;
            col_griddetail_customername.DataPropertyName = Sale.COL_CHARTDETAILBYSALES_CUSTOMERNAME;
            col_griddetail_pcs.DataPropertyName = Sale.COL_CHARTDETAILBYSALES_SALEPCS;
            col_griddetail_qty.DataPropertyName = Sale.COL_CHARTDETAILBYSALES_SALEQTY;
            col_griddetail_amount.DataPropertyName = Sale.COL_CHARTDETAILBYSALES_SALEAMOUNT;
            col_griddetail_profit.DataPropertyName = Sale.COL_CHARTDETAILBYSALES_PROFITAMOUNT;
            col_griddetail_profitpercent.DataPropertyName = Sale.COL_CHARTDETAILBYSALES_PROFITPERCENT;

            dgvDetailByProducts.AutoGenerateColumns = false;
            Tools.clearWhenSelected(dgvDetailByProducts);
            col_dgvDetailByProducts_product_id.DataPropertyName = Sale.COL_CHARTDETAILBYPRODUCTS_PRODUCTID;
            col_dgvDetailByProducts_product_name.DataPropertyName = Sale.COL_CHARTDETAILBYPRODUCTS_PRODUCTNAME;
            col_dgvDetailByProducts_sale_qty.DataPropertyName = Sale.COL_CHARTDETAILBYPRODUCTS_SALEPCS;
            col_dgvDetailByProducts_sale_length.DataPropertyName = Sale.COL_CHARTDETAILBYPRODUCTS_SALEQTY;
            col_dgvDetailByProducts_sale_amount.DataPropertyName = Sale.COL_CHARTDETAILBYPRODUCTS_SALEAMOUNT;
            col_dgvDetailByProducts_profit_amount.DataPropertyName = Sale.COL_CHARTDETAILBYPRODUCTS_PROFITAMOUNT;
            col_dgvDetailByProducts_profit_percent.DataPropertyName = Sale.COL_CHARTDETAILBYPRODUCTS_PROFITPERCENT;
            col_dgvDetailByProducts_grade.DataPropertyName = Sale.COL_CHARTDETAILBYPRODUCTS_GRADE;

            dgvDetailByCustomers.AutoGenerateColumns = false;
            Tools.clearWhenSelected(dgvDetailByCustomers);
            col_dgvDetailByCustomers_customer_id.DataPropertyName = Sale.COL_CHARTDETAILBYCUSTOMERS_CUSTOMERID;
            col_dgvDetailByCustomers_customer_name.DataPropertyName = Sale.COL_CHARTDETAILBYCUSTOMERS_CUSTOMERNAME;
            col_dgvDetailByCustomers_sale_qty.DataPropertyName = Sale.COL_CHARTDETAILBYCUSTOMERS_SALEPCS;
            col_dgvDetailByCustomers_sale_length.DataPropertyName = Sale.COL_CHARTDETAILBYCUSTOMERS_SALEQTY;
            col_dgvDetailByCustomers_sale_amount.DataPropertyName = Sale.COL_CHARTDETAILBYCUSTOMERS_SALEAMOUNT;
            col_dgvDetailByCustomers_profit_amount.DataPropertyName = Sale.COL_CHARTDETAILBYCUSTOMERS_PROFITAMOUNT;
            col_dgvDetailByCustomers_profit_percent.DataPropertyName = Sale.COL_CHARTDETAILBYCUSTOMERS_PROFITPERCENT;

            clearCharts();

            //Hidden
            col_gridsummary_sales.Visible = false;
            col_gridsummary_profit.Visible = false;
            col_gridsummary_percentage.Visible = false;

            col_dgvSummaryByCustomers_sale_amount.Visible = false;
            col_dgvSummaryByCustomers_profit_amount.Visible = false;
            col_dgvSummaryByCustomers_profit_percent.Visible = false;

            col_griddetail_amount.Visible = false;
            col_griddetail_profit.Visible = false;
            col_griddetail_profitpercent.Visible = false;

            col_dgvDetailByProducts_profit_amount.Visible = false;
            col_dgvDetailByProducts_profit_percent.Visible = false;
            col_dgvDetailByProducts_sale_amount.Visible = false;

            col_dgvDetailByCustomers_profit_amount.Visible = false;
            col_dgvDetailByCustomers_profit_percent.Visible = false;
            col_dgvDetailByCustomers_sale_amount.Visible = false;

            if (GlobalData.UserAccount.role != Roles.Super)
            {
                chkShowHidden.Visible = false;

                //chartSales.Visible = false;
                //chartProfit.Visible = false;
                tcCharts.TabPages.Remove(tpSales);
                tcCharts.TabPages.Remove(tpProfit);
                chkIsReported.Visible = false;
            }
        }

        private void populatePageData()
        {
            //setup charts
            setupChart(chartSales, "SALES per 1K");
            setupChart(chartProfit, "PROFIT per 1K");
            setupChart(chartQty, "QUANTITY");

            //populate summary by month
            DataTable dt = Sale.getChartDataByMonths(
                                    Tools.getDate(dtStart, false), 
                                    Tools.getDate(dtEnd, true),
                                    (Guid?)cbExcludeCustomers.SelectedValue,
                                    iclb_Customers.getCheckedItemsInArrayTable(Customer.COL_DB_ID),
                                    iclb_Grades.getCheckedItemsInArrayTable(Grade.COL_DB_ID),
                                    iclb_ProductStoreNames.getCheckedItemsInArrayTable(ProductStoreName.COL_DB_ID),
                                    iclb_ProductWidths.getCheckedItemsInArrayTable(ProductWidth.COL_DB_ID),
                                    iclb_LengthUnits.getCheckedItemsInArrayTable(LengthUnit.COL_DB_ID),
                                    iclb_Colors.getCheckedItemsInArrayTable(FabricColor.COL_DB_ID),
                                    chkIsReported.Checked);
            Tools.setDataTablePrimaryKey(dt, Sale.COL_CHART_SALEYEARMONTH);
            gridSummaryByMonth.DataSource = dt;
            LIBUtil.Util.setFirstDisplayedScrollingRowIndex(gridSummaryByMonth, dt.Rows.Count-1, dt.Rows.Count - 1);

            //populate charts
            int firstYear = 0, lastYear = 0;
            if (dt.Rows.Count > 0)
            {
                firstYear = Convert.ToInt32(dt.Rows[0][Sale.COL_CHART_SALEYEARMONTH].ToString().Substring(0, 4));
                lastYear = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1][Sale.COL_CHART_SALEYEARMONTH].ToString().Substring(0, 4));

                DataRow row;
                Series seriesQty;
                Series seriesSales;
                Series seriesProfit;                
                for (int year = firstYear; year <= lastYear; year++)
                {
                    seriesQty = createSeries(chartQty, year.ToString());
                    seriesSales = createSeries(chartSales, year.ToString());
                    seriesProfit = createSeries(chartProfit, year.ToString());
                    for (int month = 1; month <= 12; month++)
                    {
                        row = dt.Rows.Find(string.Format("{0}-{1:##00}", year, month));
                        if (row == null)
                        {
                            seriesQty.Points.AddXY(month, 0);
                            seriesSales.Points.AddXY(month, 0);
                            seriesProfit.Points.AddXY(month, 0);
                        }
                        else
                        {
                            seriesQty.Points.AddXY(month, row[Sale.COL_CHART_QTY]);
                            seriesSales.Points.AddXY(month, Convert.ToInt32(row[Sale.COL_CHART_TOTAL])/1000);
                            seriesProfit.Points.AddXY(month, Convert.ToInt32(row[Sale.COL_PROFIT])/1000);
                        }
                    }

                    //add total in legends
                    object value;
                    if ((value = dt.Compute(string.Format("SUM({0})", Sale.COL_CHART_QTY), string.Format("{0} LIKE '%{1}%'", Sale.COL_CHART_SALEYEARMONTH, year))) != DBNull.Value)
                        seriesQty.LegendText = string.Format("{0}: {1:N0}", year, Convert.ToInt32(value));

                    if ((value = dt.Compute(string.Format("SUM({0})", Sale.COL_CHART_TOTAL), string.Format("{0} LIKE '%{1}%'", Sale.COL_CHART_SALEYEARMONTH, year))) != DBNull.Value)
                        seriesSales.LegendText = string.Format("{0}: {1:N0}K", year, Convert.ToInt64(value) / 1000);

                    if ((value = dt.Compute(string.Format("SUM({0})", Sale.COL_CHART_PROFIT), string.Format("{0} LIKE '%{1}%'", Sale.COL_CHART_SALEYEARMONTH, year))) != DBNull.Value)
                        seriesProfit.LegendText = string.Format("{0}: {1:N0}K", year, Convert.ToInt64(value) / 1000);
                }

                chartQty.ChartAreas[0].RecalculateAxesScale();
                chartSales.ChartAreas[0].RecalculateAxesScale();
                chartProfit.ChartAreas[0].RecalculateAxesScale();

                int monthTotal = Convert.ToInt32(dt.Compute(string.Format("COUNT({0})", Sale.COL_CHART_SALEYEARMONTH), ""));
                int yearTotal = lastYear - firstYear + 1;

                decimal qtyTotal = Convert.ToDecimal(dt.Compute(string.Format("SUM({0})", Sale.COL_CHART_QTY), ""));
                addTitle(chartQty, Docking.Top, 8, Color.Black,
                    string.Format("Total {0:N0} = {1:N0} x {2} bln = {3:N0} x {4} yrs",
                        qtyTotal,
                        qtyTotal / monthTotal,
                        monthTotal,
                        qtyTotal / yearTotal,
                        yearTotal));

                decimal saleTotal = Convert.ToDecimal(dt.Compute(string.Format("SUM({0})", Sale.COL_CHART_TOTAL), ""));
                addTitle(chartSales, Docking.Top, 8, Color.Black,
                    string.Format("Total {0:N0}K = {1:N0} x {2} bln) = {3:N0} x {4} yrs",
                        saleTotal / 1000,
                        saleTotal / monthTotal,
                        monthTotal,
                        saleTotal / yearTotal,
                        yearTotal));

                decimal profitTotal = Convert.ToDecimal(dt.Compute(string.Format("SUM({0})", Sale.COL_PROFIT), ""));
                addTitle(chartProfit, Docking.Top, 8, Color.Black,
                    string.Format("Total {0:N0}K = {1:N0} x {2} bln = {3:N0} x {4} yrs",
                        profitTotal / 1000,
                        profitTotal / monthTotal,
                        monthTotal,
                        profitTotal / yearTotal,
                        yearTotal));

                //populate summary by customers
                dt = Sale.getChartDataByCustomers(
                                        Tools.getDate(dtStart, false),
                                        Tools.getDate(dtEnd, true),
                                        (Guid?)cbExcludeCustomers.SelectedValue,
                                        iclb_Customers.getCheckedItemsInArrayTable(Customer.COL_DB_ID),
                                        iclb_Grades.getCheckedItemsInArrayTable(Grade.COL_DB_ID),
                                        iclb_ProductStoreNames.getCheckedItemsInArrayTable(ProductStoreName.COL_DB_ID),
                                        iclb_ProductWidths.getCheckedItemsInArrayTable(ProductWidth.COL_DB_ID),
                                        iclb_LengthUnits.getCheckedItemsInArrayTable(LengthUnit.COL_DB_ID),
                                        iclb_Colors.getCheckedItemsInArrayTable(FabricColor.COL_DB_ID),
                                        chkIsReported.Checked);
                gridSummaryByCustomers.DataSource = dt;

            }
        }

        private void setupChart(Chart chart, string title)
        {
            chart.Series.Clear();
            chart.ChartAreas[0].AxisY.LabelStyle.Format = "{0:N0}";

            chart.Titles.Clear();
            addTitle(chart, Docking.Top, 12, Color.Black, title);

            chart.Legends[0].Docking = Docking.Bottom;
        }

        private void addTitle(Chart chart, Docking location, int fontSize, Color color, string title)
        {
            chart.Titles.Add(new Title(title, location, new Font("Arial", fontSize), color));
        }

        private Series createSeries(Chart chart, string seriesName)
        {
            Series series = chart.Series.FindByName(seriesName);
            if (series == null)
            {
                chart.ChartAreas[0].AxisX.LabelStyle.Angle = 90;

                series = chart.Series.Add(seriesName);
                series.ChartType = SeriesChartType.Column;
                series.IsValueShownAsLabel = true;
                series.LabelFormat = "{0:N0}";
                series.LabelAngle = -90;
                series.SmartLabelStyle.Enabled = false;
                series["PixelPointWidth"] = "30";
            }
            return series;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            populatePageData();
            clearGridDetail();
        }

        private void clearGridDetail()
        {
            dgvDetailBySales.DataSource = null;
        }

        private void gridSummary_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string monthYear = ((DataGridView)sender).Rows[e.RowIndex].Cells[col_gridsummary_month.Name].Value.ToString();
            string year = monthYear.Substring(0,4);
            string month = monthYear.Substring(5);
            DateTime start = Convert.ToDateTime(string.Format("{0}/{1}/1", month, year));
            DataTable dt = Sale.getChartDataDetailBySales(
                                    start,
                                    start.AddMonths(1).Date,
                                    (Guid?)cbExcludeCustomers.SelectedValue,
                                    iclb_Customers.getCheckedItemsInArrayTable(Customer.COL_DB_ID),
                                    iclb_Grades.getCheckedItemsInArrayTable(Grade.COL_DB_ID),
                                    iclb_ProductStoreNames.getCheckedItemsInArrayTable(ProductStoreName.COL_DB_ID),
                                    iclb_ProductWidths.getCheckedItemsInArrayTable(ProductWidth.COL_DB_ID),
                                    iclb_LengthUnits.getCheckedItemsInArrayTable(LengthUnit.COL_DB_ID),
                                    iclb_Colors.getCheckedItemsInArrayTable(FabricColor.COL_DB_ID),
                                    chkIsReported.Checked);
            dgvDetailBySales.DataSource = dt;
            
            //decimal qtyTotal = Convert.ToDecimal(dt.Compute(string.Format("SUM({0})", Sale.COL_CHARTDETAILBYSALES_SALEQTY), ""));
            //decimal saleTotal = Convert.ToDecimal(dt.Compute(string.Format("SUM({0})", Sale.COL_CHARTDETAILBYSALES_SALEAMOUNT), ""));
            //decimal profitTotal = Convert.ToDecimal(dt.Compute(string.Format("SUM({0})", Sale.COL_CHARTDETAILBYSALES_PROFITAMOUNT), ""));
            //MessageBox.Show(string.Format("qty: {0:N0}, amount: {1:N2}, profit: {2:N2}", qtyTotal, saleTotal, profitTotal));

            dt = Sale.getChartDataDetailByProducts(
                                    start,
                                    start.AddMonths(1).Date,
                                    (Guid?)cbExcludeCustomers.SelectedValue,
                                    iclb_Customers.getCheckedItemsInArrayTable(Customer.COL_DB_ID),
                                    iclb_Grades.getCheckedItemsInArrayTable(Grade.COL_DB_ID),
                                    iclb_ProductStoreNames.getCheckedItemsInArrayTable(ProductStoreName.COL_DB_ID),
                                    iclb_ProductWidths.getCheckedItemsInArrayTable(ProductWidth.COL_DB_ID),
                                    iclb_LengthUnits.getCheckedItemsInArrayTable(LengthUnit.COL_DB_ID),
                                    iclb_Colors.getCheckedItemsInArrayTable(FabricColor.COL_DB_ID),
                                    chkIsReported.Checked);
            dgvDetailByProducts.DataSource = dt;

            dt = Sale.getChartDataDetailByCustomers(
                                    start,
                                    start.AddMonths(1).Date,
                                    (Guid?)cbExcludeCustomers.SelectedValue,
                                    iclb_Customers.getCheckedItemsInArrayTable(Customer.COL_DB_ID),
                                    iclb_Grades.getCheckedItemsInArrayTable(Grade.COL_DB_ID),
                                    iclb_ProductStoreNames.getCheckedItemsInArrayTable(ProductStoreName.COL_DB_ID),
                                    iclb_ProductWidths.getCheckedItemsInArrayTable(ProductWidth.COL_DB_ID),
                                    iclb_LengthUnits.getCheckedItemsInArrayTable(LengthUnit.COL_DB_ID),
                                    iclb_Colors.getCheckedItemsInArrayTable(FabricColor.COL_DB_ID),
                                    chkIsReported.Checked);
            dgvDetailByCustomers.DataSource = dt;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            iclb_ProductWidths.reset();
            iclb_Grades.reset();
            iclb_ProductStoreNames.reset();
            iclb_Colors.reset();
            iclb_Customers.reset();
            iclb_LengthUnits.reset();
            Tools.resetDropDownList(cbExcludeCustomers);
            chkIsReported.Checked = false;
            dtStart.Checked = false;
            dtEnd.Checked = false;
        }

        private void gridDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Tools.isCorrectColumn(sender, e, typeof(DataGridViewLinkColumn), col_griddetail_barcode.Name))
            {
                Sale sale = new Sale(new Guid(dgvDetailBySales.Rows[e.RowIndex].Cells[col_griddetail_saleid.Name].Value.ToString()));
                var form = new Sales.Invoice_Form(sale, SaleItem.getItems(sale.id), false);
                Tools.displayForm(form);
            }
        }

        private void gridSummaryByCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable dtCustomer = LIBUtil.Util.createArrayTable();
            dtCustomer.Rows.Add((Guid)LIBUtil.Util.getSelectedRowValue((DataGridView)sender, col_dgvSummaryByCustomers_customer_id));

            DataTable dt = Sale.getChartDataDetailBySales(
                                    Tools.getDate(dtStart, false),
                                    Tools.getDate(dtEnd, true),
                                    (Guid?)cbExcludeCustomers.SelectedValue,
                                    dtCustomer,
                                    iclb_Grades.getCheckedItemsInArrayTable(Grade.COL_DB_ID),
                                    iclb_ProductStoreNames.getCheckedItemsInArrayTable(ProductStoreName.COL_DB_ID),
                                    iclb_ProductWidths.getCheckedItemsInArrayTable(ProductWidth.COL_DB_ID),
                                    iclb_LengthUnits.getCheckedItemsInArrayTable(LengthUnit.COL_DB_ID),
                                    iclb_Colors.getCheckedItemsInArrayTable(FabricColor.COL_DB_ID),
                                    chkIsReported.Checked);
            dgvDetailBySales.DataSource = dt;

            //decimal qtyTotal = Convert.ToDecimal(dt.Compute(string.Format("SUM({0})", Sale.COL_CHARTDETAILBYSALES_SALEQTY), ""));
            //decimal saleTotal = Convert.ToDecimal(dt.Compute(string.Format("SUM({0})", Sale.COL_CHARTDETAILBYSALES_SALEAMOUNT), ""));
            //decimal profitTotal = Convert.ToDecimal(dt.Compute(string.Format("SUM({0})", Sale.COL_CHARTDETAILBYSALES_PROFITAMOUNT), ""));
            //MessageBox.Show(string.Format("qty: {0:N0}, amount: {1:N2}, profit: {2:N2}", qtyTotal, saleTotal, profitTotal));

            dt = Sale.getChartDataDetailByProducts(
                                    Tools.getDate(dtStart, false),
                                    Tools.getDate(dtEnd, true),
                                    (Guid?)cbExcludeCustomers.SelectedValue,
                                    dtCustomer,
                                    iclb_Grades.getCheckedItemsInArrayTable(Grade.COL_DB_ID),
                                    iclb_ProductStoreNames.getCheckedItemsInArrayTable(ProductStoreName.COL_DB_ID),
                                    iclb_ProductWidths.getCheckedItemsInArrayTable(ProductWidth.COL_DB_ID),
                                    iclb_LengthUnits.getCheckedItemsInArrayTable(LengthUnit.COL_DB_ID),
                                    iclb_Colors.getCheckedItemsInArrayTable(FabricColor.COL_DB_ID),
                                    chkIsReported.Checked);
            dgvDetailByProducts.DataSource = dt;

            dt = Sale.getChartDataDetailByCustomers(
                                    Tools.getDate(dtStart, false),
                                    Tools.getDate(dtEnd, true),
                                    (Guid?)cbExcludeCustomers.SelectedValue,
                                    dtCustomer,
                                    iclb_Grades.getCheckedItemsInArrayTable(Grade.COL_DB_ID),
                                    iclb_ProductStoreNames.getCheckedItemsInArrayTable(ProductStoreName.COL_DB_ID),
                                    iclb_ProductWidths.getCheckedItemsInArrayTable(ProductWidth.COL_DB_ID),
                                    iclb_LengthUnits.getCheckedItemsInArrayTable(LengthUnit.COL_DB_ID),
                                    iclb_Colors.getCheckedItemsInArrayTable(FabricColor.COL_DB_ID),
                                    chkIsReported.Checked);
            dgvDetailByCustomers.DataSource = dt;
        }

        private void Filter_Item_Checked(object sender, EventArgs e)
        {
            if(gridSummaryByMonth.Rows.Count > 0)
            {
                gridSummaryByMonth.DataSource = null;
                gridSummaryByCustomers.DataSource = null;
                dgvDetailBySales.DataSource = null;
                dgvDetailByProducts.DataSource = null;
                dgvDetailByCustomers.DataSource = null;

                clearCharts();
            }
        }

        private void clearCharts()
        {
            chartQty.Titles.Clear();
            chartSales.Titles.Clear();
            chartProfit.Titles.Clear();
            chartQty.Series.Clear();
            chartSales.Series.Clear();
            chartProfit.Series.Clear();
        }

        private void chkShowHidden_CheckedChanged(object sender, EventArgs e)
        {
            col_gridsummary_sales.Visible = chkShowHidden.Checked;
            col_gridsummary_profit.Visible = chkShowHidden.Checked;
            col_gridsummary_percentage.Visible = chkShowHidden.Checked;

            col_dgvSummaryByCustomers_sale_amount.Visible = chkShowHidden.Checked;
            col_dgvSummaryByCustomers_profit_amount.Visible = chkShowHidden.Checked;
            col_dgvSummaryByCustomers_profit_percent.Visible = chkShowHidden.Checked;

            col_griddetail_amount.Visible = chkShowHidden.Checked;
            col_griddetail_profit.Visible = chkShowHidden.Checked;
            col_griddetail_profitpercent.Visible = chkShowHidden.Checked;

            col_dgvDetailByProducts_profit_amount.Visible = chkShowHidden.Checked;
            col_dgvDetailByProducts_profit_percent.Visible = chkShowHidden.Checked;
            col_dgvDetailByProducts_sale_amount.Visible = chkShowHidden.Checked;

            col_dgvDetailByCustomers_profit_amount.Visible = chkShowHidden.Checked;
            col_dgvDetailByCustomers_profit_percent.Visible = chkShowHidden.Checked;
            col_dgvDetailByCustomers_sale_amount.Visible = chkShowHidden.Checked;
        }

        private void Sales_Form_Shown(object sender, EventArgs e)
        {
            //default start date
            dtStart.Value = new DateTime(DateTime.Now.Year - 3, 1, 1);
            dtStart.Checked = false;

            if (GlobalData.UserAccount.role == Roles.Super)
            {
                chkShowHidden.Checked = true;
                btnSubmit.PerformClick();
            }
        }
    }
}
