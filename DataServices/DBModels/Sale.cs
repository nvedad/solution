using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataServices.DBModels;

public partial class Sale
{
    public string StorId { get; set; } = null!;

    public string OrdNum { get; set; } = null!;

    public DateTime OrdDate { get; set; }

    public short Qty { get; set; }
   
    public string Payterms { get; set; } = null!;
  
    public string TitleId { get; set; } = null!;
    
    public virtual Title Title { get; set; } = null!;
}


