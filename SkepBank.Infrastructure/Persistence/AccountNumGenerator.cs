using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using SkepBank.Application.Common.Interfaces.Persistence;
using SkepBank.Application.Common.Interfaces.Services;

namespace SkepBank.Domain.Utilities;

public class AccountNumGenerator : IAccountNumGenerator
{
    private const int _checkDigits = 17;
    private const string _countryCode = "GE";
    private const string _bankCode = "SKEP";
    private const int _accountNumLength = 20;
    private IDictionary<int, int> _validAccountNums = new Dictionary<int, int>();

    protected string getCountryCode()
    {
        return _countryCode;
    }
    protected string getBankCode()
    {
        return _bankCode;
    }
    protected string getDigits()
    {
        string result;

        int last = _validAccountNums[_checkDigits];
        last++;

        result = last.ToString().PadLeft(_accountNumLength, '0');

        _validAccountNums[_checkDigits]++;

        return result;
    }
    protected string getCheckDigits()
    {
        return _checkDigits.ToString();
    }

    string IAccountNumGenerator.GenerateAccountNum()
    {
        string result = "";

        result += getCountryCode();
        result += getCheckDigits();
        result += getBankCode();
        result += getDigits();

        return result;
    }
}
