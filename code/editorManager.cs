using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class editorManager : MonoBehaviour
{
    PlayerActionMap playerAction;
    public Camera main, editor;
    public GameObject[] prefabs;

    bool editorMode = false;
    int lastTypeInstantiated = -1;

    

    // Start is called before the first frame update
    void Start()
    {
        playerAction = playerController.instance.playerInput;
        playerAction.editor.Enable();
        playerAction.editor.enableEditor.performed += cntxt => SwitchCamera();
        playerAction.editor.addItem1.performed += cntxt => addItem(0);
        playerAction.editor.addItem2.performed += cntxt => addItem(1);
        playerAction.editor.dropitem.performed += cntxt => dropItem();
        main.enabled = true;
        editor.enabled = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void dropItem()
    {

    }

    public void addItem(int i)
    {
        if (!editor  || lastTypeInstantiated == i)
        {
            return;
        }

      GameObject g =  Instantiate(prefabs[i]);
        g.transform.position = playerController.instance.gameObject.transform.position + Vector3.up;
        lastTypeInstantiated = i;

    }

    public void SwitchCamera()
    {
        main.enabled = !main.enabled;
        editor.enabled = !editor.enabled;
    }

    // Update is called once per frame
    void Update()
    {
        if (main.enabled || !editor.enabled)
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            return;
        }

        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;

    }
}
