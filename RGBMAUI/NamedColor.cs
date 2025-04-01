using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RGBMAUI
{
    public class NamedColor : INotifyPropertyChanged
    {
        Color _color;
        string _name;
        int _red;
        int _green;
        int _blue;

        public event PropertyChangedEventHandler PropertyChanged;

        public Color Color
        {
            get
            {
                return _color;
            }
            set
            {
                if (_color != value)
                {
                    _color = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Color"));
                }
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
                }
            }
        }

        public int Red
        {
            get
            {
                return _red;
            }
            set
            {
                if (_red != value)
                {
                    _red = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Red"));
                }
            }
        }

        public int Green
        {
            get
            {
                return _green;
            }
            set
            {
                if (_green != value)
                {
                    _green = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Green"));
                }
            }
        }

        public int Blue
        {
            get
            {
                return _blue;
            }
            set
            {
                if (_blue != value)
                {
                    _blue = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Blue"));
                }
            }
        }

        public NamedColor()
        {
        }

        public NamedColor(string name, int red, int green, int blue)
        {
            Name = name;
            Red = red;
            Green = green;
            Blue = blue;
        }

        public override string ToString()
        {
            return Name;
        }
    }
        
    }
    
