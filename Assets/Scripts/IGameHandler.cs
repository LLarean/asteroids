using EventBusSystem;

public interface IGameHandler : IGlobalSubscriber
{
    void HandleHealthChange();
    void HandleExperienceChange();
}