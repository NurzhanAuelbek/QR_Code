using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;
namespace QR_Code
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //считываем текст из TextBox'a
            string qrtext = textBox1.Text;
            //создаём новую "генерацию кода"
            QRCodeEncoder encoder = new QRCodeEncoder();
            // кодируем слово, полученное из TextBox'a (qrtext) в переменную qrcode.
            // класса Bitmap(класс, который используется для работы с изображениями)
            Bitmap qrcode = encoder.Encode(qrtext);
            // pictureBox выводит qrcode как изображение.
            pictureBox1.Image = qrcode as Image;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // save будет запрашивать у пользователя место, в которое он захочет сохранить файл.
            SaveFileDialog save = new SaveFileDialog();
            //создаём фильтр, который определяет, в каких форматах мы сможем сохранить нашу информацию.
            //В данном случае выбираем форматы изображений. Записывается так:
            //"название_формата_в обозревателе|*.расширение_формата")
            save.Filter = "PNG|*.png|JPEG|*.jpg|GIF|*.gif|BMP|*.bmp";
            //если пользователь нажимает в обозревателе кнопку "Сохранить".
            if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK) 
            {
                //изображение из pictureBox'a сохраняется под именем, которое введёт пользователь
                pictureBox1.Image.Save(save.FileName); 
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //  load будет запрашивать у пользователя место, из которого он хочет загрузить файл.
            OpenFileDialog load = new OpenFileDialog();
            //если пользователь нажимает в обозревателе кнопку "Открыть".
            if (load.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // в pictureBox'e открывается файл, который был по пути, запрошенном пользователем.
                pictureBox1.ImageLocation = load.FileName; 
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // создаём "раскодирование изображения"
            QRCodeDecoder decoder = new QRCodeDecoder();
            //в MessageBox'e программа запишет раскодированное сообщение с изображения,
            //которое предоврительно будет переведено из pictureBox'a в класс Bitmap,
            //чтобы мы смогли с этим изображением работать.
            MessageBox.Show(decoder.Decode(new QRCodeBitmapImage(pictureBox1.Image as Bitmap))); 
        }
    }
}
