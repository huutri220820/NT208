﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DataLayer.Entities
{
    public class Inbox
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public DateTime DateCreate { get; set; }
        public string Content { get; set; }
        // username nguoi gui
        public string Sender { get; set; }
        // username nguoi nhan
        public string Receiver { get; set; }
    }

    public class InboxConfiguration : IEntityTypeConfiguration<Inbox>
    {
        public void Configure(EntityTypeBuilder<Inbox> builder)
        {
            builder.Property(x => x.DateCreate).IsRequired(true).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.Content).IsRequired(true);
            builder.Property(x => x.Receiver).IsRequired(true);
            builder.Property(x => x.Sender).IsRequired(true);
        }
    }
}