using Application.DTOs;
using Domain.Entities;

namespace Aplication.Interfaces;

public interface IOrderProcessorService
{
    Task ProcessOrderAsync(OrderRequestDTO requestDto);
}