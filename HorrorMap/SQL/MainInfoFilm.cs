//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HorrorMap.SQL
{
    using System;
    using System.Collections.Generic;
    
    public partial class MainInfoFilm
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string CountryCreator { get; set; }
        public byte[] ImageMovie { get; set; }
        public string Operator { get; set; }
        public string Genres { get; set; }
        public Nullable<int> idCreators { get; set; }
        public Nullable<int> idFilmDescription { get; set; }
        public Nullable<int> idBudgetAndFees { get; set; }
        public Nullable<int> idAgeLimit { get; set; }
        public Nullable<int> idRentalData { get; set; }
    
        public virtual AgeLimit AgeLimit { get; set; }
        public virtual BudgetAndFees BudgetAndFees { get; set; }
        public virtual Creators Creators { get; set; }
        public virtual FilmDescription FilmDescription { get; set; }
        public virtual RentalData RentalData { get; set; }
    }
}
