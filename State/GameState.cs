namespace CustomProgram.State
{
    public interface GameState //state pattern
    {
        void NextState();
        void PreviousState();
        void Update();
        void FreeAllSprites();
        void FreeAllMusics();

    }
}
