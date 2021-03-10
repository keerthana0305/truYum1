using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using truYum1.Models;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace truYum1.Models
{
    public class menu
    {
        public int id
        {
            set;
            get;
        }

        public String name
        {
            get;
            set;
        }

        public int price
        {
            get;
            set;
        }


        public String date
        {
            get;
            set;
        }
        public String category
        {
            get;
            set;
        }

        public bool active
        {
            get;
            set;
        }
        public bool free
        {
            get;
            set;
        }
    }
}