#pragma strict

import System.IO;

public var Lives: int = 9;
public var Objectives;

private var lifeCounter: GUIText;

function OnGUI () 
{
 	GUI.Label (Rect (10, 10, 100, 20), String.Concat(Lives.ToString()," Lives"));
}