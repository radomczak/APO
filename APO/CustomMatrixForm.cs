using Emgu.CV.CvEnum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APO
{
    public partial class CustomMatrixForm : Form
    {
        private int matrixSize;
        private float[,] kernel;
        private BorderType borderType;
        private int borderConstant;

        public CustomMatrixForm()
        {
            InitializeComponent();
        }

        public int MatrixSize
        {
            get { return matrixSize; }
        }

        public float[,] Kernel
        {
            get { return kernel; }
        }

        public int BorderConstant
        {
            get { return borderConstant; }
        }



        private void InitializeMatrix()
        {
            switch(matrixSize)
            {
                case 3:
                    Prepare3x3();
                    break;
                case 5:
                    Prepare5x5();
                    break;
                case 7:
                    Prepare7x7();
                    break;
                case 9:
                    Prepare9x9();
                    break;

            }
        }

        private void Prepare3x3()
        {
            disableMatrix();
            Box00.Visible = true;
            Box01.Visible = true;
            Box02.Visible = true;
            Box10.Visible = true;
            Box11.Visible = true;
            Box12.Visible = true;
            Box20.Visible = true;
            Box21.Visible = true;
            Box22.Visible = true;
            /*
            Box00.Text = "1";
            Box01.Text = "1";
            Box02.Text = "1";
            Box10.Text = "1";
            Box11.Text = "1";
            Box12.Text = "1";
            Box20.Text = "1";
            Box21.Text = "1";
            Box22.Text = "1";
            */
        }
        private void Prepare5x5()
        {
            disableMatrix();
            Box00.Visible = true;
            Box01.Visible = true;
            Box02.Visible = true;
            Box03.Visible = true;
            Box04.Visible = true;
            Box10.Visible = true;
            Box11.Visible = true;
            Box12.Visible = true;
            Box13.Visible = true;
            Box14.Visible = true;
            Box20.Visible = true;
            Box21.Visible = true;
            Box22.Visible = true;
            Box23.Visible = true;
            Box24.Visible = true;
            Box30.Visible = true;
            Box31.Visible = true;
            Box32.Visible = true;
            Box33.Visible = true;
            Box34.Visible = true;
            Box40.Visible = true;
            Box41.Visible = true;
            Box42.Visible = true;
            Box43.Visible = true;
            Box44.Visible = true;

            /*
            Box00.Text = "1";
            Box01.Text = "1";
            Box02.Text = "1";
            Box03.Text = "1";
            Box04.Text = "1";
            Box10.Text = "1";
            Box11.Text = "1";
            Box12.Text = "1";
            Box13.Text = "1";
            Box14.Text = "1";
            Box20.Text = "1";
            Box21.Text = "1";
            Box22.Text = "1";
            Box23.Text = "1";
            Box24.Text = "1";
            Box30.Text = "1";
            Box31.Text = "1";
            Box32.Text = "1";
            Box33.Text = "1";
            Box34.Text = "1";
            Box40.Text = "1";
            Box41.Text = "1";
            Box42.Text = "1";
            Box43.Text = "1";
            Box44.Text = "1";
            */
        }
        private void Prepare7x7()
        {
            disableMatrix();
            Box00.Visible = true;
            Box01.Visible = true;
            Box02.Visible = true;
            Box03.Visible = true;
            Box04.Visible = true;
            Box05.Visible = true;
            Box06.Visible = true;
            Box10.Visible = true;
            Box11.Visible = true;
            Box12.Visible = true;
            Box13.Visible = true;
            Box14.Visible = true;
            Box15.Visible = true;
            Box16.Visible = true;
            Box20.Visible = true;
            Box21.Visible = true;
            Box22.Visible = true;
            Box23.Visible = true;
            Box24.Visible = true;
            Box25.Visible = true;
            Box26.Visible = true;
            Box30.Visible = true;
            Box31.Visible = true;
            Box32.Visible = true;
            Box33.Visible = true;
            Box34.Visible = true;
            Box35.Visible = true;
            Box36.Visible = true;
            Box40.Visible = true;
            Box41.Visible = true;
            Box42.Visible = true;
            Box43.Visible = true;
            Box44.Visible = true;
            Box45.Visible = true;
            Box46.Visible = true;
            Box50.Visible = true;
            Box51.Visible = true;
            Box52.Visible = true;
            Box53.Visible = true;
            Box54.Visible = true;
            Box55.Visible = true;
            Box56.Visible = true;
            Box60.Visible = true;
            Box61.Visible = true;
            Box62.Visible = true;
            Box63.Visible = true;
            Box64.Visible = true;
            Box65.Visible = true;
            Box66.Visible = true;

            /*
            Box00.Text = "1";
            Box01.Text = "1";
            Box02.Text = "1";
            Box03.Text = "1";
            Box04.Text = "1";
            Box05.Text = "1";
            Box06.Text = "1";
            Box10.Text = "1";
            Box11.Text = "1";
            Box12.Text = "1";
            Box13.Text = "1";
            Box14.Text = "1";
            Box15.Text = "1";
            Box16.Text = "1";
            Box20.Text = "1";
            Box21.Text = "1";
            Box22.Text = "1";
            Box23.Text = "1";
            Box24.Text = "1";
            Box25.Text = "1";
            Box26.Text = "1";
            Box30.Text = "1";
            Box31.Text = "1";
            Box32.Text = "1";
            Box33.Text = "1";
            Box34.Text = "1";
            Box35.Text = "1";
            Box36.Text = "1";
            Box40.Text = "1";
            Box41.Text = "1";
            Box42.Text = "1";
            Box43.Text = "1";
            Box44.Text = "1";
            Box45.Text = "1";
            Box46.Text = "1";
            Box50.Text = "1";
            Box51.Text = "1";
            Box52.Text = "1";
            Box53.Text = "1";
            Box54.Text = "1";
            Box55.Text = "1";
            Box56.Text = "1";
            Box60.Text = "1";
            Box61.Text = "1";
            Box62.Text = "1";
            Box63.Text = "1";
            Box64.Text = "1";
            Box65.Text = "1";
            Box66.Text = "1";
            */
        }
        private void Prepare9x9()
        {
            disableMatrix();
            Box00.Visible = true;
            Box01.Visible = true;
            Box02.Visible = true;
            Box03.Visible = true;
            Box04.Visible = true;
            Box05.Visible = true;
            Box06.Visible = true;
            Box07.Visible = true;
            Box08.Visible = true;
            Box10.Visible = true;
            Box11.Visible = true;
            Box12.Visible = true;
            Box13.Visible = true;
            Box14.Visible = true;
            Box15.Visible = true;
            Box16.Visible = true;
            Box17.Visible = true;
            Box18.Visible = true;
            Box20.Visible = true;
            Box21.Visible = true;
            Box22.Visible = true;
            Box23.Visible = true;
            Box24.Visible = true;
            Box25.Visible = true;
            Box26.Visible = true;
            Box27.Visible = true;
            Box28.Visible = true;
            Box30.Visible = true;
            Box30.Visible = true;
            Box31.Visible = true;
            Box32.Visible = true;
            Box33.Visible = true;
            Box34.Visible = true;
            Box35.Visible = true;
            Box36.Visible = true;
            Box37.Visible = true;
            Box38.Visible = true;
            Box40.Visible = true;
            Box41.Visible = true;
            Box42.Visible = true;
            Box43.Visible = true;
            Box44.Visible = true;
            Box45.Visible = true;
            Box46.Visible = true;
            Box47.Visible = true;
            Box48.Visible = true;
            Box50.Visible = true;
            Box51.Visible = true;
            Box52.Visible = true;
            Box53.Visible = true;
            Box54.Visible = true;
            Box55.Visible = true;
            Box56.Visible = true;
            Box57.Visible = true;
            Box58.Visible = true;
            Box60.Visible = true;
            Box61.Visible = true;
            Box62.Visible = true;
            Box63.Visible = true;
            Box64.Visible = true;
            Box65.Visible = true;
            Box66.Visible = true;
            Box67.Visible = true;
            Box68.Visible = true;
            Box70.Visible = true;
            Box71.Visible = true;
            Box72.Visible = true;
            Box73.Visible = true;
            Box74.Visible = true;
            Box75.Visible = true;
            Box76.Visible = true;
            Box77.Visible = true;
            Box78.Visible = true;
            Box80.Visible = true;
            Box81.Visible = true;
            Box82.Visible = true;
            Box83.Visible = true;
            Box84.Visible = true;
            Box85.Visible = true;
            Box86.Visible = true;
            Box87.Visible = true;
            Box88.Visible = true;

            /*
            Box00.Text = "1";
            Box01.Text = "1";
            Box02.Text = "1";
            Box03.Text = "1";
            Box04.Text = "1";
            Box05.Text = "1";
            Box06.Text = "1";
            Box07.Text = "1";
            Box08.Text = "1";
            Box10.Text = "1";
            Box11.Text = "1";
            Box12.Text = "1";
            Box13.Text = "1";
            Box14.Text = "1";
            Box15.Text = "1";
            Box16.Text = "1";
            Box17.Text = "1";
            Box18.Text = "1";
            Box20.Text = "1";
            Box21.Text = "1";
            Box22.Text = "1";
            Box23.Text = "1";
            Box24.Text = "1";
            Box25.Text = "1";
            Box26.Text = "1";
            Box27.Text = "1";
            Box28.Text = "1";
            Box30.Text = "1";
            Box30.Text = "1";
            Box31.Text = "1";
            Box32.Text = "1";
            Box33.Text = "1";
            Box34.Text = "1";
            Box35.Text = "1";
            Box36.Text = "1";
            Box37.Text = "1";
            Box38.Text = "1";
            Box40.Text = "1";
            Box41.Text = "1";
            Box42.Text = "1";
            Box43.Text = "1";
            Box44.Text = "1";
            Box45.Text = "1";
            Box46.Text = "1";
            Box47.Text = "1";
            Box48.Text = "1";
            Box50.Text = "1";
            Box51.Text = "1";
            Box52.Text = "1";
            Box53.Text = "1";
            Box54.Text = "1";
            Box55.Text = "1";
            Box56.Text = "1";
            Box57.Text = "1";
            Box58.Text = "1";
            Box60.Text = "1";
            Box61.Text = "1";
            Box62.Text = "1";
            Box63.Text = "1";
            Box64.Text = "1";
            Box65.Text = "1";
            Box66.Text = "1";
            Box67.Text = "1";
            Box68.Text = "1";
            Box70.Text = "1";
            Box71.Text = "1";
            Box72.Text = "1";
            Box73.Text = "1";
            Box74.Text = "1";
            Box75.Text = "1";
            Box76.Text = "1";
            Box77.Text = "1";
            Box78.Text = "1";
            Box80.Text = "1";
            Box81.Text = "1";
            Box82.Text = "1";
            Box83.Text = "1";
            Box84.Text = "1";
            Box85.Text = "1";
            Box86.Text = "1";
            Box87.Text = "1";
            Box88.Text = "1";
            */
        }

        private void disableMatrix()
        {
            Box00.Visible = false;
            Box01.Visible = false;
            Box02.Visible = false;
            Box03.Visible = false;
            Box04.Visible = false;
            Box05.Visible = false;
            Box06.Visible = false;
            Box07.Visible = false;
            Box08.Visible = false;
            Box10.Visible = false;
            Box11.Visible = false;
            Box12.Visible = false;
            Box13.Visible = false;
            Box14.Visible = false;
            Box15.Visible = false;
            Box16.Visible = false;
            Box17.Visible = false;
            Box18.Visible = false;
            Box20.Visible = false;
            Box21.Visible = false;
            Box22.Visible = false;
            Box23.Visible = false;
            Box24.Visible = false;
            Box25.Visible = false;
            Box26.Visible = false;
            Box27.Visible = false;
            Box28.Visible = false;
            Box30.Visible = false;
            Box30.Visible = false;
            Box31.Visible = false;
            Box32.Visible = false;
            Box33.Visible = false;
            Box34.Visible = false;
            Box35.Visible = false;
            Box36.Visible = false;
            Box37.Visible = false;
            Box38.Visible = false;
            Box40.Visible = false;
            Box41.Visible = false;
            Box42.Visible = false;
            Box43.Visible = false;
            Box44.Visible = false;
            Box45.Visible = false;
            Box46.Visible = false;
            Box47.Visible = false;
            Box48.Visible = false;
            Box50.Visible = false;
            Box51.Visible = false;
            Box52.Visible = false;
            Box53.Visible = false;
            Box54.Visible = false;
            Box55.Visible = false;
            Box56.Visible = false;
            Box57.Visible = false;
            Box58.Visible = false;
            Box60.Visible = false;
            Box61.Visible = false;
            Box62.Visible = false;
            Box63.Visible = false;
            Box64.Visible = false;
            Box65.Visible = false;
            Box66.Visible = false;
            Box67.Visible = false;
            Box68.Visible = false;
            Box70.Visible = false;
            Box71.Visible = false;
            Box72.Visible = false;
            Box73.Visible = false;
            Box74.Visible = false;
            Box75.Visible = false;
            Box76.Visible = false;
            Box77.Visible = false;
            Box78.Visible = false;
            Box80.Visible = false;
            Box81.Visible = false;
            Box82.Visible = false;
            Box83.Visible = false;
            Box84.Visible = false;
            Box85.Visible = false;
            Box86.Visible = false;
            Box87.Visible = false;
            Box88.Visible = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = comboBox1.SelectedIndex;
            switch(i)
            {
                case 0:
                    matrixSize = 3;
                    break;
                case 1:
                    matrixSize = 5;
                    break;
                case 2:
                    matrixSize = 7;
                    break;
                case 3:
                    matrixSize = 9;
                    break;
            }
            InitializeMatrix();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int x = comboBox2.SelectedIndex;
            switch(x)
            {
                case 0:
                    borderType = BorderType.Constant;
                    GetMatrixSizeForm form = new GetMatrixSizeForm("Wartość:");
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        borderConstant = form.GetSize();
                    }
                    break;
                case 1:
                    borderType = BorderType.Replicate;
                    break;
                case 2:
                    borderType = BorderType.Reflect;
                    break;
                case 3:
                    borderType = BorderType.Wrap;
                    break;
                case 4:
                    borderType = BorderType.Reflect101;
                    break;
                case 5:
                    borderType = BorderType.Transparent;
                    break;
                case 6:
                    borderType = BorderType.Isolated;
                    break;
                case 7:
                    borderType = BorderType.Default;
                    break;
            }

        }

        private void updateKernelForSize(int size)
        {
            switch (size)
            {
                case 3:
                    kernel[0,0] = ParseOrZero(Box00.Text);
                    kernel[0,1] = ParseOrZero(Box01.Text);
                    kernel[0,2] = ParseOrZero(Box02.Text);
                    kernel[1,0] = ParseOrZero(Box10.Text);
                    kernel[1,1] = ParseOrZero(Box11.Text);
                    kernel[1,2] = ParseOrZero(Box12.Text);
                    kernel[2,0] = ParseOrZero(Box20.Text);
                    kernel[2,1] = ParseOrZero(Box21.Text);
                    kernel[2,2] = ParseOrZero(Box22.Text);
                    break;
                case 5:
                    kernel[0,0] = ParseOrZero(Box00.Text);
                    kernel[0,1] = ParseOrZero(Box01.Text);
                    kernel[0,2] = ParseOrZero(Box02.Text);
                    kernel[0,3] = ParseOrZero(Box03.Text);
                    kernel[0,4] = ParseOrZero(Box04.Text);
                    kernel[1,0] = ParseOrZero(Box10.Text);
                    kernel[1,1] = ParseOrZero(Box11.Text);
                    kernel[1,2] = ParseOrZero(Box12.Text);
                    kernel[1,3] = ParseOrZero(Box13.Text);
                    kernel[1,4] = ParseOrZero(Box14.Text);
                    kernel[2,0] = ParseOrZero(Box20.Text);
                    kernel[2,1] = ParseOrZero(Box21.Text);
                    kernel[2,2] = ParseOrZero(Box22.Text);
                    kernel[2,3] = ParseOrZero(Box23.Text);
                    kernel[2,4] = ParseOrZero(Box24.Text);
                    kernel[3,0] = ParseOrZero(Box30.Text);
                    kernel[3,1] = ParseOrZero(Box31.Text);
                    kernel[3,2] = ParseOrZero(Box32.Text);
                    kernel[3,3] = ParseOrZero(Box33.Text);
                    kernel[3,4] = ParseOrZero(Box34.Text);
                    kernel[4,0] = ParseOrZero(Box40.Text);
                    kernel[4,1] = ParseOrZero(Box41.Text);
                    kernel[4,2] = ParseOrZero(Box42.Text);
                    kernel[4,3] = ParseOrZero(Box43.Text);
                    kernel[4,4] = ParseOrZero(Box44.Text);
                    break;
                case 7: 
                    kernel[0,0] = ParseOrZero(Box00.Text);
                    kernel[0,1] = ParseOrZero(Box01.Text);
                    kernel[0,2] = ParseOrZero(Box02.Text);
                    kernel[0,3] = ParseOrZero(Box03.Text);
                    kernel[0,4] = ParseOrZero(Box04.Text);
                    kernel[0,5] = ParseOrZero(Box05.Text);
                    kernel[0,6] = ParseOrZero(Box06.Text);
                    kernel[1,0] = ParseOrZero(Box10.Text);
                    kernel[1,1] = ParseOrZero(Box11.Text);
                    kernel[1,2] = ParseOrZero(Box12.Text);
                    kernel[1,3] = ParseOrZero(Box13.Text);
                    kernel[1,4] = ParseOrZero(Box14.Text);
                    kernel[1,5] = ParseOrZero(Box15.Text);
                    kernel[1,6] = ParseOrZero(Box16.Text);
                    kernel[2,0] = ParseOrZero(Box20.Text);
                    kernel[2,1] = ParseOrZero(Box21.Text);
                    kernel[2,2] = ParseOrZero(Box22.Text);
                    kernel[2,3] = ParseOrZero(Box23.Text);
                    kernel[2,4] = ParseOrZero(Box24.Text);
                    kernel[2,5] = ParseOrZero(Box25.Text);
                    kernel[2,6] = ParseOrZero(Box26.Text);
                    kernel[3,0] = ParseOrZero(Box30.Text);
                    kernel[3,1] = ParseOrZero(Box31.Text);
                    kernel[3,2] = ParseOrZero(Box32.Text);
                    kernel[3,3] = ParseOrZero(Box33.Text);
                    kernel[3,4] = ParseOrZero(Box34.Text);
                    kernel[3,5] = ParseOrZero(Box35.Text);
                    kernel[3,6] = ParseOrZero(Box36.Text);
                    kernel[4,0] = ParseOrZero(Box40.Text);
                    kernel[4,1] = ParseOrZero(Box41.Text);
                    kernel[4,2] = ParseOrZero(Box42.Text);
                    kernel[4,3] = ParseOrZero(Box43.Text);
                    kernel[4,4] = ParseOrZero(Box44.Text);
                    kernel[4,5] = ParseOrZero(Box45.Text);
                    kernel[4,6] = ParseOrZero(Box46.Text);
                    kernel[5,0] = ParseOrZero(Box50.Text);
                    kernel[5,1] = ParseOrZero(Box51.Text);
                    kernel[5,2] = ParseOrZero(Box52.Text);
                    kernel[5,3] = ParseOrZero(Box53.Text);
                    kernel[5,4] = ParseOrZero(Box54.Text);
                    kernel[5,5] = ParseOrZero(Box55.Text);
                    kernel[5,6] = ParseOrZero(Box56.Text);
                    kernel[6,0] = ParseOrZero(Box60.Text);
                    kernel[6,1] = ParseOrZero(Box61.Text);
                    kernel[6,2] = ParseOrZero(Box62.Text);
                    kernel[6,3] = ParseOrZero(Box63.Text);
                    kernel[6,4] = ParseOrZero(Box64.Text);
                    kernel[6,5] = ParseOrZero(Box65.Text);
                    kernel[6,6] = ParseOrZero(Box66.Text);
                    break;
                case 9: 
                    kernel[0,0] = ParseOrZero(Box00.Text);
                    kernel[0,1] = ParseOrZero(Box01.Text);
                    kernel[0,2] = ParseOrZero(Box02.Text);
                    kernel[0,3] = ParseOrZero(Box03.Text);
                    kernel[0,4] = ParseOrZero(Box04.Text);
                    kernel[0,5] = ParseOrZero(Box05.Text);
                    kernel[0,6] = ParseOrZero(Box06.Text);
                    kernel[0,7] = ParseOrZero(Box07.Text);
                    kernel[0,8] = ParseOrZero(Box08.Text);
                    kernel[1,0] = ParseOrZero(Box10.Text);
                    kernel[1,1] = ParseOrZero(Box11.Text);
                    kernel[1,2] = ParseOrZero(Box12.Text);
                    kernel[1,3] = ParseOrZero(Box13.Text);
                    kernel[1,4] = ParseOrZero(Box14.Text);
                    kernel[1,5] = ParseOrZero(Box15.Text);
                    kernel[1,6] = ParseOrZero(Box16.Text);
                    kernel[1,7] = ParseOrZero(Box17.Text);
                    kernel[1,8] = ParseOrZero(Box18.Text);
                    kernel[2,0] = ParseOrZero(Box20.Text);
                    kernel[2,1] = ParseOrZero(Box21.Text);
                    kernel[2,2] = ParseOrZero(Box22.Text);
                    kernel[2,3] = ParseOrZero(Box23.Text);
                    kernel[2,4] = ParseOrZero(Box24.Text);
                    kernel[2,5] = ParseOrZero(Box25.Text);
                    kernel[2,6] = ParseOrZero(Box26.Text);
                    kernel[2,7] = ParseOrZero(Box27.Text);
                    kernel[2,8] = ParseOrZero(Box28.Text);
                    kernel[3,0] = ParseOrZero(Box30.Text);
                    kernel[3,1] = ParseOrZero(Box30.Text);
                    kernel[3,2] = ParseOrZero(Box31.Text);
                    kernel[3,3] = ParseOrZero(Box32.Text);
                    kernel[3,4] = ParseOrZero(Box33.Text);
                    kernel[3,5] = ParseOrZero(Box34.Text);
                    kernel[3,6] = ParseOrZero(Box35.Text);
                    kernel[3,7] = ParseOrZero(Box36.Text);
                    kernel[3,8] = ParseOrZero(Box37.Text);
                    kernel[4,0] = ParseOrZero(Box38.Text);
                    kernel[4,1] = ParseOrZero(Box40.Text);
                    kernel[4,2] = ParseOrZero(Box41.Text);
                    kernel[4,3] = ParseOrZero(Box42.Text);
                    kernel[4,4] = ParseOrZero(Box43.Text);
                    kernel[4,5] = ParseOrZero(Box44.Text);
                    kernel[4,6] = ParseOrZero(Box45.Text);
                    kernel[4,7] = ParseOrZero(Box46.Text);
                    kernel[4,8] = ParseOrZero(Box47.Text);
                    kernel[5,0] = ParseOrZero(Box48.Text);
                    kernel[5,1] = ParseOrZero(Box50.Text);
                    kernel[5,2] = ParseOrZero(Box51.Text);
                    kernel[5,3] = ParseOrZero(Box52.Text);
                    kernel[5,4] = ParseOrZero(Box53.Text);
                    kernel[5,5] = ParseOrZero(Box54.Text);
                    kernel[5,6] = ParseOrZero(Box55.Text);
                    kernel[5,7] = ParseOrZero(Box56.Text);
                    kernel[5,8] = ParseOrZero(Box57.Text);
                    kernel[6,0] = ParseOrZero(Box58.Text);
                    kernel[6,1] = ParseOrZero(Box60.Text);
                    kernel[6,2] = ParseOrZero(Box61.Text);
                    kernel[6,3] = ParseOrZero(Box62.Text);
                    kernel[6,4] = ParseOrZero(Box63.Text);
                    kernel[6,5] = ParseOrZero(Box64.Text);
                    kernel[6,6] = ParseOrZero(Box65.Text);
                    kernel[6,7] = ParseOrZero(Box66.Text);
                    kernel[6,8] = ParseOrZero(Box67.Text);
                    kernel[7,0] = ParseOrZero(Box68.Text);
                    kernel[7,1] = ParseOrZero(Box70.Text);
                    kernel[7,2] = ParseOrZero(Box71.Text);
                    kernel[7,3] = ParseOrZero(Box72.Text);
                    kernel[7,4] = ParseOrZero(Box73.Text);
                    kernel[7,5] = ParseOrZero(Box74.Text);
                    kernel[7,6] = ParseOrZero(Box75.Text);
                    kernel[7,7] = ParseOrZero(Box76.Text);
                    kernel[7,8] = ParseOrZero(Box77.Text);
                    kernel[8,0] = ParseOrZero(Box78.Text);
                    kernel[8,1] = ParseOrZero(Box80.Text);
                    kernel[8,2] = ParseOrZero(Box81.Text);
                    kernel[8,3] = ParseOrZero(Box82.Text);
                    kernel[8,4] = ParseOrZero(Box83.Text);
                    kernel[8,5] = ParseOrZero(Box84.Text);
                    kernel[8,6] = ParseOrZero(Box85.Text);
                    kernel[8,7] = ParseOrZero(Box86.Text);
                    kernel[8,8] = ParseOrZero(Box87.Text);
                    break;
            }
        }

        private void OK_Click(object sender, EventArgs e)
        {
            kernel = new float[matrixSize, matrixSize];
            updateKernelForSize(matrixSize);
        }

        private float ParseOrZero(string s)
        {
            if (s.Length > 0)
                try
                {
                    return float.Parse(s, CultureInfo.InvariantCulture);

                }
                catch
                {
                    return 0;
                }
            else return 0;
        }

        public float[,] getKernel()
        {
            return kernel;
        }

        public BorderType GetBorderType()
        {
            return borderType;
        }

        public int getSize()
        {
            return matrixSize;
        }
    }
}
