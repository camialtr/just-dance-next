using UnityEngine;

public static class InputManager
{
    public static bool Undo()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Backspace))
        {
            return true;
        }
        if (Server.mainDancer != -1 && Server.Dancer[Server.mainDancer].networkData.newInput)
        {
            if (Server.Dancer[Server.mainDancer].networkData.networkInput == NetworkInput.Undo)
            {
                Server.Dancer[Server.mainDancer].networkData.newInput = false;
                return true;
            }
        }
        return false;
    }

    public static bool Select()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            return true;
        }
        if (Server.mainDancer != -1 && Server.Dancer[Server.mainDancer].networkData.newInput)
        {
            if (Server.Dancer[Server.mainDancer].networkData.networkInput == NetworkInput.Select)
            {
                Server.Dancer[Server.mainDancer].networkData.newInput = false;
                return true;
            }
        }
        return false;
    }

    public static bool Up()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            return true;
        }
        if (Server.mainDancer != -1 && Server.Dancer[Server.mainDancer].networkData.newInput)
        {
            if (Server.Dancer[Server.mainDancer].networkData.networkInput == NetworkInput.Up)
            {
                Server.Dancer[Server.mainDancer].networkData.newInput = false;
                return true;
            }
        }
        return false;
    }

    public static bool Down()
    {
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            return true;
        }
        if (Server.mainDancer != -1 && Server.Dancer[Server.mainDancer].networkData.newInput)
        {
            if (Server.Dancer[Server.mainDancer].networkData.networkInput == NetworkInput.Down)
            {
                Server.Dancer[Server.mainDancer].networkData.newInput = false;
                return true;
            }
        }
        return false;
    }

    public static bool Left()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            return true;
        }
        if (Server.mainDancer != -1 && Server.Dancer[Server.mainDancer].networkData.newInput)
        {
            if (Server.Dancer[Server.mainDancer].networkData.networkInput == NetworkInput.Left)
            {
                Server.Dancer[Server.mainDancer].networkData.newInput = false;
                return true;
            }
        }
        return false;
    }

    public static bool Right()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            return true;
        }
        if (Server.mainDancer != -1 && Server.Dancer[Server.mainDancer].networkData.newInput)
        {
            if (Server.Dancer[Server.mainDancer].networkData.networkInput == NetworkInput.Right)
            {
                Server.Dancer[Server.mainDancer].networkData.newInput = false;
                return true;
            }
        }
        return false;
    }
}
