﻿namespace TrafficCourts.Messaging.MessageContracts
{
    /// <summary>
    /// An enumeration of Plea Type on a DisputedCount record.
    /// </summary>
    public enum Plea
    {
        /// <summary>
        /// Unknown type (undefined). Must be index 0.
        /// </summary>
        Unknown,

        /// <summary>
        /// If the disputant is pleads guilty, plea will always be Guilty. The disputant has choice to attend court or not.
        /// </summary>
        G,

        /// <summary>
        /// If the disputant is pleads not guilty, the disputant will have to attend court.
        /// </summary>
        N
    }
}
