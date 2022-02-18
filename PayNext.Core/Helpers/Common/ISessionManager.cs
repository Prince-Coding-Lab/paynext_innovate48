﻿using PayNext.Core.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace PayNext.Core.Helpers.Common
{
  public interface ISessionManager
  {
    void SetSession(UserDto loginResponseDto);
    string GetString(string key);
    int? GetInt(string key);
    void SetString(string key, string value);
    void SetInt(string key, int value);
    void Remove(string key);
    //string GetApiToken();
    void SetObject(string key, object value);
    T GetObject<T>(string key);

    bool IsActive();
    public string GetCookie(string key, bool name = true);
    public void SetCookie(string key, string value, int? expireTime);
    public void RemoveCookie(string key);
  }
}
