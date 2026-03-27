using System;

public static class GameEvents
{
    //канали для новин. <int> передає новину разом з числом
    public static Action<int> OnCoinCollected;
    public static Action<int> OnPlayerDamaged;
    public static Action OnLevelFinished;
}