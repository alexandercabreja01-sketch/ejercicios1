using System;

abstract class Character
{
    private readonly string _characterType;

    protected Character(string characterType)
    {
        _characterType = characterType;
    }

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable()
    {
        return false;
    }

    public override string ToString()
    {
        return $"Character is a {_characterType}";
    }
}

class Warrior : Character
{
    public Warrior() : base("Warrior")
    {
    }

    public override int DamagePoints(Character target)
    {
        return target.Vulnerable() ? 10 : 6;
    }
}

class Wizard : Character
{
    private bool _spellPrepared = false;

    public Wizard() : base("Wizard")
    {
    }

    public override bool Vulnerable()
    {
        return !_spellPrepared;
    }

    public override int DamagePoints(Character target)
    {
        return _spellPrepared ? 12 : 3;
    }

    public void PrepareSpell()
    {
        _spellPrepared = true;
    }
}

class Program
{
    static void Main()
    {
       

        var warrior = new Warrior();
        var wizard = new Wizard();

        Console.WriteLine($" {warrior}"); 
        Console.WriteLine($"   {wizard}");  
        Console.WriteLine(" Estado Inicial ");
        Console.WriteLine($" ¿Guerrero vulnerable?: {warrior.Vulnerable()}"); 
        Console.WriteLine($" ¿Mago vulnerable sin hechizo?: {wizard.Vulnerable()}"); 

        Console.WriteLine(" Ataques (Sin Hechizo)");
        Console.WriteLine($" Mago inflige a Guerrero: {wizard.DamagePoints(warrior)} ptos"); 
        Console.WriteLine($" Guerrero inflige a Mago vulnerable: {warrior.DamagePoints(wizard)} ptos"); 

        Console.WriteLine(" El Mago prepara un hechizo ");
        wizard.PrepareSpell();

        Console.WriteLine($" ¿Mago vulnerable tras preparar hechizo?: {wizard.Vulnerable()}"); 
        Console.WriteLine($" Mago inflige a Guerrero (con hechizo): {wizard.DamagePoints(warrior)} ptos"); 
        Console.WriteLine($" Guerrero inflige a Mago protegido: {warrior.DamagePoints(wizard)} ptos"); 
    }
}
