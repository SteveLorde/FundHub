﻿namespace FundHubAPI.Data.DTOs.RequestDTO;

public class DonationRequestDTO
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid ProjectId { get; set; }
    public DateOnly Date { get; set; }
    public decimal DonationAmount { get; set; }
}