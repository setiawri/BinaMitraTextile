﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BinaMitraTextileWebApp
{
    public enum PaymentMethods
    {
        Cash,
        EDC,
        Transfer,
        Credit,
        Giro,
        Hutang,
        [Description("Lain-lain")]
        Lainlain
    };

    public enum EnumReminderStatuses : byte
    {
        New,
        [Description("In Progress")]
        [Display(Name = "In Progress")]
        InProgress,
        [Description("On Hold")]
        [Display(Name = "On Hold")]
        OnHold,
        Waiting,
        Completed,
        Cancel
    }

    public enum EnumActions
    {
        Create,
        Edit,
        Update,
        Delete,
        Print,
        Approve,
        Cancel,
        Previous,
        Next
    }

    public enum EnumActionTypes
    {
        All = 0
    }

    public enum DayOfWeekEnum : byte
    {
        Senin,
        Selasa,
        Rabu,
        Kamis,
        Jumat,
        Sabtu,
        Minggu
    }
}