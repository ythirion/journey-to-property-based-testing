﻿using System.Collections.Immutable;

namespace PBTKata.Bank
{
    public record Account(
        decimal Balance,
        bool IsOverdraftAuthorized,
        Amount MaxWithdrawal,
        ImmutableList<Withdraw>? Withdraws)
    {
        public ImmutableList<Withdraw> Withdraws { get; init; } = Withdraws ?? ImmutableList<Withdraw>.Empty;

        public Account Withdraw(Withdraw command)
        {
            return this with
            {
                Balance = Balance - command.Amount.Value,
                Withdraws = Withdraws.Add(command)
            };
        }
    }
}