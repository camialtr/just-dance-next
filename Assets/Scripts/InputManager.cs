using UnityEngine;

public static class InputManager
{
    public static bool Undo()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Backspace))
        {
            return true;
        }
        if (Server.mainDancer != -1 && Server.Dancer[Server.mainDancer].newInput)
        {
            Server.Dancer[Server.mainDancer].newInput = false;
            return Server.Dancer[Server.mainDancer].networkData.networkInput == NetworkInput.Undo;
        }
        return false;
    }

    public static bool Select()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            return true;
        }
        if (Server.mainDancer != -1 && Server.Dancer[Server.mainDancer].newInput)
        {
            Server.Dancer[Server.mainDancer].newInput = false;
            return Server.Dancer[Server.mainDancer].networkData.networkInput == NetworkInput.Select;
        }
        return false;
    }

    public static bool Up()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            return true;
        }
        if (Server.mainDancer != -1 && Server.Dancer[Server.mainDancer].newInput)
        {
            Server.Dancer[Server.mainDancer].newInput = false;
            return Server.Dancer[Server.mainDancer].networkData.networkInput == NetworkInput.Up;
        }
        return false;
    }

    public static bool Down()
    {
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            return true;
        }
        if (Server.mainDancer != -1 && Server.Dancer[Server.mainDancer].newInput)
        {
            Server.Dancer[Server.mainDancer].newInput = false;
            return Server.Dancer[Server.mainDancer].networkData.networkInput == NetworkInput.Down;
        }
        return false;
    }

    public static bool Left()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            return true;
        }
        if (Server.mainDancer != -1 && Server.Dancer[Server.mainDancer].newInput)
        {
            Server.Dancer[Server.mainDancer].newInput = false;
            return Server.Dancer[Server.mainDancer].networkData.networkInput == NetworkInput.Left;
        }
        return false;
    }

    public static bool Right()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            return true;
        }
        if (Server.mainDancer != -1 && Server.Dancer[Server.mainDancer].newInput)
        {
            Server.Dancer[Server.mainDancer].newInput = false;
            return Server.Dancer[Server.mainDancer].networkData.networkInput == NetworkInput.Right;
        }
        return false;
    }
}
