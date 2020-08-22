using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormCollage {
    public partial class Form1 : Form {

        SqlConnection connection =
                    new SqlConnection("data source=.; database=Collage; integrated security=SSPI");

        public Form1()
        {
            InitializeComponent();
        }

        private void addStudentBtn_Click(object sender, EventArgs e)
        {
            StudentForm sForm = new StudentForm(connection);
            sForm.Show();
        }

        private void addTeacherBtn_Click(object sender, EventArgs e)
        {

        }

        private void addHeadTeachBtn_Click(object sender, EventArgs e)
        {
            HeadTeachForm htForm = new HeadTeachForm(connection);
            htForm.Show();
        }
    }
}
