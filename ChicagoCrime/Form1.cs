using System;
using System.Windows.Forms;


namespace ChicagoCrime
{
  public partial class Form1 : Form
  {
     public Form1()
    {
      InitializeComponent();
    }

    private bool doesFileExist(string filename)
    {
      if (!System.IO.File.Exists(filename))
      {
        string msg = string.Format("Input file not found: '{0}'",
          filename);

        MessageBox.Show(msg);
        return false;
      }

      // exists!
      return true;
    }

    private void clearForm()
    {
      // 
      // if a chart is being displayed currently, remove it:
      //
      if (this.graphPanel.Controls.Count > 0)
      {
        this.graphPanel.Controls.RemoveAt(0);
        this.graphPanel.Refresh();
      }
    }

    private void cmdByYear_Click(object sender, EventArgs e)
    {
      string filename = this.txtFilename.Text;

      if (!doesFileExist(filename))
        return;

      clearForm();

      //
      // Call over to F# code to analyze data and return a 
      // chart to display:
      //
      this.Cursor = Cursors.WaitCursor;

      var chart = FSAnalysis.CrimesByYear(filename);

      this.Cursor = Cursors.Default;

      //
      // we have chart, display it:
      //
      this.graphPanel.Controls.Add(chart);
      this.graphPanel.Refresh();
    }

        private void cmdArrestPct_Click(object sender, EventArgs e)
        {
            string filename = this.txtFilename.Text;

            if (!doesFileExist(filename))
                return;

            clearForm();

            //
            // Call over to F# code to analyze data and return a 
            // chart to display:
            //
            this.Cursor = Cursors.WaitCursor;

            var chart = FSAnalysis.ArrestVsYear(filename);

            this.Cursor = Cursors.Default;

            //
            // we have chart, display it:
            //
            this.graphPanel.Controls.Add(chart);
            this.graphPanel.Refresh();
        }
        private void cmdByCrime_Click(object sender, EventArgs e)
        {
            string filename = this.txtFilename.Text;
            string filename2 = "IUCR-codes.csv";
            string codeVal = crimeCodeTextBox.Text;
            
            if (!doesFileExist(filename))
                return;

            clearForm();

            //
            // Call over to F# code to analyze data and return a 
            // chart to display:
            //
            this.Cursor = Cursors.WaitCursor;

            var chart = FSAnalysis.CrimeCodeVsYear(filename, filename2, codeVal);

            this.Cursor = Cursors.Default;

            //
            // we have chart, display it:
            //
            this.graphPanel.Controls.Add(chart);
            this.graphPanel.Refresh();
        }
        private void cmdByArea_Click(object sender, EventArgs e)
        {
            string filename = this.txtFilename.Text;
            string filename2 = "Areas.csv";
            string areaVal = byAreaTextBox.Text;

            
            if (!doesFileExist(filename))
                return;

            clearForm();

            //
            // Call over to F# code to analyze data and return a 
            // chart to display:
            //
            this.Cursor = Cursors.WaitCursor;

            var chart = FSAnalysis.CrimesInAreaVsYear(filename, filename2, areaVal);

            this.Cursor = Cursors.Default;

            //
            // we have chart, display it:
            //
            this.graphPanel.Controls.Add(chart);
            this.graphPanel.Refresh();
        }

        private void cmdChicago_Click(object sender, EventArgs e)
        {
            string filename = this.txtFilename.Text;
            string filename2 = "Areas.csv";

            if (!doesFileExist(filename))
                return;

            clearForm();

            //
            // Call over to F# code to analyze data and return a 
            // chart to display:
            //
            this.Cursor = Cursors.WaitCursor;

            var chart = FSAnalysis.AllCrimesByArea(filename, filename2);

            this.Cursor = Cursors.Default;

            //
            // we have chart, display it:
            //
            this.graphPanel.Controls.Add(chart);
            this.graphPanel.Refresh();
        }

    }//class
}//namespace
