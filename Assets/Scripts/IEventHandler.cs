﻿using EventBusSystem;

public interface IEventHandler : IGlobalSubscriber
{
    void HandleDestroySpaceship();
}