﻿using System.Data.Common;

namespace Digitalantiz.Common.Application.Data;

public interface IDbConnectionFactory
{
    ValueTask<DbConnection> OpenConnectionAsync();
}
