using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Track.Order.Api.Contracts.Order;
using Track.Order.Application.Interfaces;
using Track.Order.Common;
using Track.Order.Common.Models;

namespace Track.Order.Api.Controllers;

[ApiController]
[Route("/order")]
public class OrderController : Controller
{
    private readonly IOrderService _orderService;
    private readonly IMapper _mapper;

    public OrderController(IOrderService orderService, IMapper mapper)
    {
        _orderService = orderService;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetOrderByIdAsync([FromRoute] int id)
    {
        var serviceResult = await _orderService.GetOrderByIdAsync(id);

        if (serviceResult.IsFailure)
            return serviceResult.BuildErrorResult();

        var result = IturriResult.Success(_mapper.Map<OrderResponse>(serviceResult.Data));
        return result.BuildResult<OrderResponse>();
    }

    [HttpGet()]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllOrderAsync()
    {
        var serviceResult = await _orderService.GetAllOrderAsync();

        if (serviceResult.IsFailure)
            return serviceResult.BuildErrorResult();

        var orderResponses = _mapper.Map<List<OrderResponse>>(serviceResult.Data);

        var result = IturriResult.Success(orderResponses);
        return result.BuildResult<List<OrderResponse>>(); ;
    }

}
