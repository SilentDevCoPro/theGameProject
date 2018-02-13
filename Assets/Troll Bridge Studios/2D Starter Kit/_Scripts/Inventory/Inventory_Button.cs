using UnityEngine;
using System.Collections;

namespace TrollBridge {

	public class Inventory_Button : MonoBehaviour {

        public GameObject wep;
        public GameObject wepText;

		public void OpenCloseInventory(){
			// Open or close the inventory.
			Grid.inventory.OpenCloseInventory();
            if(!wep.activeSelf)
            {
                wep.SetActive(true);
                wepText.SetActive(true);
            }
            else
            {
                wep.SetActive(false);
                wepText.SetActive(false);
            }
		}
	}
}
