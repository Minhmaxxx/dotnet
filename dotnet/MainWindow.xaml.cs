using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace dotnet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        List<NhanVien> dsNhanVien = new List<NhanVien>();
        List<NhanVien> dsTuoimax = new List<NhanVien>();
        private void button_Nhap_Click(object sender, RoutedEventArgs e)
        {
            if (isKiemtra())
            {
                NhanVien nv = new NhanVien();
                nv.MaNV = int.Parse(txtMaNV.Text);
                nv.HoTen = txtHoten.Text;
                nv.NgaySinh = Convert.ToDateTime(txtNgaysinh.Text);
                if (rbtn_Nam.IsChecked == true)
                {
                    nv.GioiTinh = "Nam";
                }
                else
                {
                    nv.GioiTinh = "Nữ";
                }
                nv.PhongBan = txtPhongban.Text;
                nv.HeSoLuong = double.Parse(txtHeSoLuong.Text);
                dsNhanVien.Add(nv);
                ketqua.ItemsSource = null;
                ketqua.ItemsSource = dsNhanVien; 
            }
            
        }

        private void button_Window2_Click(object sender, RoutedEventArgs e)
        {
            int Tuoimax = dsNhanVien[0].Tuoi;

            for (int i = 0; i < dsNhanVien.Count; i++)
            {
                if (dsNhanVien[i].Tuoi > Tuoimax)
                {
                    Tuoimax = dsNhanVien[i].Tuoi;  
                }
            }
            foreach (var item in dsNhanVien)
            {
                if(item.Tuoi == Tuoimax)
                {
                    dsTuoimax.Add(item);    
                }
            }
            Window1 window1 = new Window1();
            window1.ketquaTuoimax.ItemsSource = dsTuoimax;
            window1.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtNgaysinh.SelectedDate = DateTime.Now;    
        }
        private bool isKiemtra()
        {

            if(txtMaNV.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã nhân viên", "Lỗi nhập", MessageBoxButton.OK, MessageBoxImage.Error);
                txtMaNV.Focus();    
                return false;
            }
            if (txtHoten.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập họ tên", "Lỗi nhập", MessageBoxButton.OK, MessageBoxImage.Error);
                txtHoten.Focus();
                return false;
            }
            if (txtHeSoLuong.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập hệ số lương", "Lỗi nhập", MessageBoxButton.OK, MessageBoxImage.Error);
                txtHeSoLuong.Focus();
                return false;
            }
            
            if(DateTime.Now.Year - txtNgaysinh.SelectedDate.Value.Year < 18)
            {
                MessageBox.Show("Tuổi phải lớn hơn 18", "Lỗi nhập", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (double.Parse(txtHeSoLuong.Text) <= 0)
            {
                MessageBox.Show("Hệ số lương mà nhỏ hơn hay bằng 0 à? Nhập lại", "Lỗi nhập", MessageBoxButton.OK, MessageBoxImage.Error);
                txtHeSoLuong.Focus();
                return false;
            }
            try
            {
                double.Parse(txtHeSoLuong.Text);
            }
            catch
            {
                MessageBox.Show("Hệ số lương phải là số thực", "Lỗi nhập", MessageBoxButton.OK, MessageBoxImage.Error);
                txtHeSoLuong.SelectAll();
                txtHeSoLuong.Focus();
                return false;
            }
            return true;
        }
    }
}