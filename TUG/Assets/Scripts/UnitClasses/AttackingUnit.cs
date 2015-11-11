using UnityEngine;
using System.Collections;

public abstract class AttackingUnit : BaseUnit
{
	public int attackDmg = 2;
	public abstract void attack(DamagableEntity enemy);// all classes that inherit from this MUST IMPLEMENT THIS using overide
}
