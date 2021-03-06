﻿using DB.Api.Application.Models;
using MediatR;
using System.Collections.Generic;

namespace DB.Api.Application.Queries
{
    public class GetChatMessageListQuery: IRequest<IEnumerable<GetChatMessageListQueryResponse>>
    {
    }
}
