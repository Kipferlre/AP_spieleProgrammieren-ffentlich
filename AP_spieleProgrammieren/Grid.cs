using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Versuch_01
{
    public class Grid
    {
        private Rectangle[,] _rectangles;
        private Point _startingPoint;
        private Size _startingSize;
        private Size _rectangleSize;
        private Form _form;
        private int _amzahlFelderWidth;
        private int _amzahlFelderHeight;

        public  Grid(Form form, Point startingPoint, Size startingSize, Size rectangleSize)
        {
            this._form = form;
            this._startingPoint = startingPoint;
            this._startingSize = startingSize;
            this._rectangleSize = rectangleSize;
            double number1 = Convert.ToDouble(startingSize.Width)/Convert.ToDouble(rectangleSize.Width);
            double number2 = Convert.ToDouble(startingSize.Height)/ Convert.ToDouble(rectangleSize.Height);
            this._rectangles = new Rectangle[Round(number1),Round(number2)];
            FillRectangleArr();
            SetPositionRectangleArr(0,0);
        }
        public Grid(Form form, Point startingPoint, Size rectangleSize, int anzahlFelderWidth, int anzahlFelderHeight)

        {
            this._form = form;
            this._startingPoint = startingPoint;
            this._rectangleSize = rectangleSize;
            this._amzahlFelderHeight = anzahlFelderHeight;
            this._amzahlFelderWidth = anzahlFelderWidth;
            this._rectangles = new Rectangle[anzahlFelderWidth,anzahlFelderHeight];
            FillRectangleArr();
            SetPositionRectangleArr(0, 0);
        }
        
        public void FillRectangleArr()
        {
            for (int i = 0; i < this._rectangles.GetLength(0); i++)
            {
                for (int a = 0; a < this._rectangles.GetLength(1); a++)
                {
                    Rectangle rectangle = new Rectangle();
                    rectangle.Size = this._rectangleSize;
                    this._rectangles[i, a] = rectangle;
                }
            }
        }
        public void SetPositionRectangleArr(int XOffSet, int YOffSet)
        {
            

            for (int i = 0; i < _rectangles.GetLength(0); i++)
            {
                for (int a = 0; a < _rectangles.GetLength(1); a++)
                {
                    this._rectangles[i, a].Location = new Point(_startingPoint.X + (_rectangleSize.Width* i) + XOffSet, _startingPoint.Y + (_rectangleSize.Height     * a) + YOffSet);
                }
            }
        }
        public Rectangle[,] getRectangleArr()
        {
            return _rectangles;
        }
        protected virtual void deimama()
        {
            MessageBox.Show("deimama");
        }
        #region void_Round
        private int Round(double Number)
        {
            int result = 0;
            String value = Number.ToString();
            if (contains(",", value))
            {
                int zwischenZahl = Convert.ToInt32(value.Substring(value.IndexOf(".") + 1, 1));

                if (zwischenZahl < 5)
                    result = Convert.ToInt32(Number);
                else
                {
                    result = Convert.ToInt32(Number);
                    result = +1;
                }
            }
            else
                result = Convert.ToInt32(Number);
            return result;
        }
        private int Round(float Number)
        {

            int result = 0;
            String value = Number.ToString();
            if (contains(",", value))
            {
                int zwischenZahl = Convert.ToInt32(value.Substring(value.IndexOf(".") + 1, 1));

                if (zwischenZahl < 5)
                    result = Convert.ToInt32(Number);
                else
                {
                    result = Convert.ToInt32(Number);
                    result = +1;
                }
            }
            else
                result = Convert.ToInt32(Number);
            return result;
        }
        private int Round(decimal Number)
        {

            int result = 0;
            String value = Number.ToString();
            if (contains(",", value))
            {
                int zwischenZahl = Convert.ToInt32(value.Substring(value.IndexOf(".") + 1, 1));

                if (zwischenZahl < 5)
                    result = Convert.ToInt32(Number);
                else
                {
                    result = Convert.ToInt32(Number);
                    result = +1;
                }
            }
            else
                result = Convert.ToInt32(Number);
            return result;
        }
        private int Round(long Number)
        {

            int result = 0;
            String value = Number.ToString();
            if (contains(",", value))
            {
                int zwischenZahl = Convert.ToInt32(value.Substring(value.IndexOf(".") + 1, 1));

                if (zwischenZahl < 5)
                    result = Convert.ToInt32(Number);
                else
                {
                    result = Convert.ToInt32(Number);
                    result = +1;
                }
            }
            else
                result = Convert.ToInt32(Number);
            return result;
        }
        private int Round(byte Number)
        {

            int result = 0;
            String value = Number.ToString();
            if (contains(",", value))
            {
                int zwischenZahl = Convert.ToInt32(value.Substring(value.IndexOf(".") + 1, 1));

                if (zwischenZahl < 5)
                    result = Convert.ToInt32(Number);
                else
                {
                    result = Convert.ToInt32(Number);
                    result = +1;
                }
            }
            else
                result = Convert.ToInt32(Number);
            return result;
        }
        private int Round(short Number)
        {

            int result = 0;
            String value = Number.ToString();
            if (contains(",", value))
            {
                int zwischenZahl = Convert.ToInt32(value.Substring(value.IndexOf(".") + 1, 1));

                if (zwischenZahl < 5)
                    result = Convert.ToInt32(Number);
                else
                {
                    result = Convert.ToInt32(Number);
                    result = +1;
                }
            }
            else
                result = Convert.ToInt32(Number);
            return result;
        }
        #endregion
        #region void_contains
        public bool contains(String Buchstaben, String Wort)
        {

            bool enthalten = false;
            String wort = Wort;
            for (int i = 0; i < Wort.Length; i++)
            {

                

                if (((wort.Length - i) - Buchstaben.Length) >= 0)
                {
                    if (wort.Substring(i, Buchstaben.Length).Equals(Buchstaben))
                    {
                        enthalten = true;
                    }
                }
            }
            return enthalten;
        }
        #endregion
    }
}
