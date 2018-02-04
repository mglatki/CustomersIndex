using CustomersIndex.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersIndex.Models
{
    public class IndividualClient : IClient
    {
        private string _name;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        private string _city;

        public string City
        {
            get
            {
                return _city;
            }
            set
            {
                _city = value;
            }
        }

        private bool _isBusinessClient;
        public bool IsBusinessClient
        {
            get
            {
                return _isBusinessClient;
            }
            set
            {
                _isBusinessClient = value;
            }
        }

        private int _id;
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        private string _country;
        public string Country
        {
            get
            {
                return _country;
            }
            set
            {
                _country = value;
            }
        }

        private string _street;
        public string Street
        {
            get
            {
                return _street;
            }
            set
            {
                _street = value;
            }
        }

        private string _streetNumber;
        public string StreetNumber
        {
            get
            {
                return _streetNumber;
            }
            set
            {
                _streetNumber = value;
            }
        }

        private string _phone;
        public string Phone
        {
            get
            {
                return _phone;
            }
            set
            {
                _phone = value;
            }
        }

        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }

        public IndividualClient(int id, string name, string country, string city, string street, string streetNumber, string phone, string email)
        {
            _id = id;
            _name = name;
            _country = country;
            _city = city;
            _street = street;
            _streetNumber = streetNumber;
            _phone = phone;
            _email = email;
            _isBusinessClient = false;
        }
    }
}
