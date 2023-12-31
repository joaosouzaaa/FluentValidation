﻿using FluentValidation.API.Interfaces.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FluentValidation.API.Filters;

public sealed class NotificationFilter : ActionFilterAttribute
{
    private readonly INotificationHandler _notificationHandler;

    public NotificationFilter(INotificationHandler notificationHandler)
    {
        _notificationHandler = notificationHandler;
    }

    public override void OnActionExecuted(ActionExecutedContext context)
    {
        if (_notificationHandler.HasNotification())
            context.Result = new BadRequestObjectResult(_notificationHandler.GetNotifications());

        base.OnActionExecuted(context);
    }
}
