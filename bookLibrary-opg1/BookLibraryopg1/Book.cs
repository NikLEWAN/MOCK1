using System;

namespace BookLibraryopg1
{
    public class Book
    {
        private string _titel;
        public string titel
        {
            get { return _titel; }
            set { _titel = value; }
        }

        private string _forfatter;
        public string forfatter
        {
            get { return _forfatter; }
            set
            {
                if (value.Length <= 2)
                {
                    throw new ArgumentException("Navn skal være længere end et bogstav");
                }
                _forfatter = value;
            }
        }

        private int _sidetal;
        public int sidetal
        {
            get { return _sidetal; }
            set
            {
                if (value <= 4)
                {
                    throw new ArgumentException("For lidt sider");
                }
                if (value >= 1000)
                {
                    throw new ArgumentException("For mange sider");
                }
                _sidetal = value;
            }
        }

        private string _Isbn13;
        public string Isbn13
        {
            get { return _Isbn13; }
            set
            {
                if (value.Length != 13)
                {
                    throw new ArgumentException("Isbn13 Skal består af 13 numre");
                }
                _Isbn13 = value;
            }
        }

        public Book(string t ,string f,int s, string i)
        {
            titel = t;
            forfatter = f;
            sidetal = s;
            Isbn13 = i;
        }

    }
}
