abstract class Character
{
    private string _characterType;
    protected virtual bool IsSpellPrepared => true;
    
    protected Character(string characterType)
    {
        _characterType = characterType;
    }

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable() => !IsSpellPrepared;

    public override string ToString() {return $"Character is a {_characterType}";}

}

class Warrior : Character
{
    public Warrior() : base("Warrior")
    {
    }

    public override int DamagePoints(Character target)
    {
        if (target.Vulnerable()) return 10;
        return 6;
    }
}

class Wizard : Character
{
    private bool spellPrepared = false;
    public Wizard() : base("Wizard")
    {
    }

    public override int DamagePoints(Character target)
    {
        if (spellPrepared) return 12;
        return 3;
    }

    protected override bool IsSpellPrepared => spellPrepared;
    public void PrepareSpell() => spellPrepared = true;
}
