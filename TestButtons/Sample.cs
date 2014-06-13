using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestButtons
{
   
        class Sample : INotifyPropertyChanged
        {
            private string firstName;
            public string FirstName
            {
                get { return firstName; }
                set
                {
                    firstName = value;
                    InvokePropertyChanged(new PropertyChangedEventArgs("FirstName"));
                }
            }

            #region Implementation of INotifyPropertyChanged

            public event PropertyChangedEventHandler PropertyChanged;

            private void InvokePropertyChanged(PropertyChangedEventArgs e)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null) handler(this, e);
            }

            #endregion
        }
}
