﻿using DontLetMeExpire.Services;
using System.Windows.Input;

namespace DontLetMeExpire.ViewModels;

public class MainViewModel : ViewModelBase
{

    private DummyItemService _itemService = new DummyItemService();

    private int _stockCount;

	public int StockCount
    {
        get => _stockCount;
        set => SetProperty(ref _stockCount, value);
    }

	private int _expiresSoonCount;

	public int ExpiresSoonCount
    {
        get => _expiresSoonCount;
        set => SetProperty(ref _expiresSoonCount, value);
    }

    private int _expiresTodayCount;
    public int ExpiresTodayCount
    {
        get => _expiresTodayCount;
        set => SetProperty(ref _expiresTodayCount, value);
    }

    private int _expiredCount;
    public int ExpiredCount
    {
        get => _expiredCount;
        set => SetProperty(ref _expiredCount, value);
    }

    public ICommand NavigateToAddItemCommand { get; }

    private Task NavigateToAddItem()
    {
        return Task.CompletedTask;
    }

    public MainViewModel()
    {
        NavigateToAddItemCommand = new Command(async () => await NavigateToAddItem());
    }

    public async Task InitializeAsync()
    {
        StockCount = (await _itemService.GetAsync()).Count();
        ExpiresSoonCount = (await _itemService.GetExpiresSoonAsync()).Count();
        ExpiresTodayCount = (await _itemService.GetExpiresTodayAsync()).Count();
        ExpiredCount = (await _itemService.GetExpiredAsync()).Count();
    }


}