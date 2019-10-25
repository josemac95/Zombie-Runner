using UnityEngine;

public class Ammo : MonoBehaviour
{
	// Slots de munición disponibles para el jugador
	[SerializeField] AmmoSlot[] ammoSlots = null;

	// Clase privada solo visible dentro de la clase Ammo
	// Variables públicas para que sean accesibles para la clase Ammo
	// Serializa la clase para que se muestre en el inspector
	// Slot de munición
	[System.Serializable]
	private class AmmoSlot
	{
		// Tipo de munición
		public AmmoType ammoType = 0;
		// Cantidad de munición
		public int ammoAmount = 0;
	}

	// Cantidad actual
	public int GetCurrentAmmo(AmmoType ammoType)
	{
		return GetAmmoSlot(ammoType).ammoAmount;
	}

	// Disminuye la cantidad
	public void ReduceCurrentAmmo(AmmoType ammoType)
	{
		GetAmmoSlot(ammoType).ammoAmount--;
	}

	// Aumenta la cantidad
	public void IncreaseCurrentAmmo(AmmoType ammoType, int ammoAmount)
	{
		GetAmmoSlot(ammoType).ammoAmount += ammoAmount;
	}

	// Obtiene el slot de munición correspondiente con el tipo de munición
	private AmmoSlot GetAmmoSlot(AmmoType ammoType)
	{
		foreach (AmmoSlot slot in ammoSlots)
		{
			if (slot.ammoType == ammoType)
			{
				return slot;
			}
		}
		return null;
	}
}
