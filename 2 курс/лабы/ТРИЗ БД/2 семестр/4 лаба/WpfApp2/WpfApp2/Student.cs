//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp2
{
    using System;
    using System.Collections.Generic;
    
    public partial class Student
    {
        public int id_student { get; set; }
        public string surname { get; set; }
        public string name { get; set; }
        public string first_name { get; set; }
        public Nullable<int> group_number { get; set; }
        public string telephone_number { get; set; }
        public string city_of_registration { get; set; }
        public string birth_date { get; set; }
    
        public virtual Groups Groups { get; set; }
    }
}
