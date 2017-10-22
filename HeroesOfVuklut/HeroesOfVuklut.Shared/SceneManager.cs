public abstract class SceneManager<T> : IScene
{

    public virtual void BeginScene(SceneParameter<T> sceneParameter){

    }

    public virtual void Update(decimal step)
    {

    }
    public virtual void Draw()
    {

    }

    public class SceneParameter<U> where U : T
    {

    }
}

public interface IScene
{
    void Update(decimal step);
    void Draw();
}