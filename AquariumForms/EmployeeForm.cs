using AquariumData.Entities;

namespace AquariumForms
{
    public partial class EmployeeForm : Form
    {
        public EmployeeForm()
        {
            InitializeComponent();
        }
        public EmployeeForm(Userr curEmployee)
        {
            InitializeComponent();
            this.currentEmployee = curEmployee;
        }
        private Userr currentEmployee { get; set; }
    }
}
