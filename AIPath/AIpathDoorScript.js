var cells = new Array();
var doorsToCells = new Array();
var immediateCells = new Array();
var testForCells:boolean = true;
var waitToTestCells:int = 2;
var stage:int = 1;

//For actual doors
var doorOpen:boolean = true;

function Awake()
{
	doorOpen = true;
	cells = GameObject.FindGameObjectsWithTag("AIpathCell");
	doorsToCells.length = cells.length;
	testForCells = true;
	waitToTestCells = 2;
	stage = 1;
}

function Update()
{
	if(testForCells&&waitToTestCells<=0)
	{
		//immediateCell is specifically for this 'for' loop.
		//This 'for' is for the first stage
		for(var immediateCell:GameObject in immediateCells)
		{
			for(var i:int = 0; i<cells.length; i++)
			{
				if(cells[i]==immediateCell)
				{
					doorsToCells[i] = 1;
				}
			}
			
			//for stage 2 and up
			for(stage=2; stage<=cells.length; stage++)
			{
				for(i=0; i<cells.length; i++)
				{
					if(doorsToCells[i] == stage-1)
					{
						for(var checkDoor:GameObject in cells[i].GetComponent(AIpathCellScript).doors)
						{
							if(checkDoor != gameObject)
							{
								for(var checkCell : GameObject in checkDoor.GetComponent(AIpathDoorScript).immediateCells)
								{
									for(var j:int = 0; j<cells.length; j++)
									{
										if(cells[j] == checkCell && doorsToCells[j]==null)
										{
											doorsToCells[j] = stage;										
										}
									}
								}
							}
						}
					}
				}
			}
		}
	
		testForCells=false;
	}	
	waitToTestCells--;
}

function OnTriggerEnter(other : Collider)
{
	if(other.tag=="AIpathCell")
	{
		immediateCells.Add(other.gameObject);
	}
}