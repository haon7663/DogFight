using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public void Interact(Player interated);
    public GameObject GameObject { get; set; }
}
