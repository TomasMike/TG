namespace TG.Enums
{
    public enum AttackType
    {
        Wound,
        WoundUnavoidable,
        LooseRedCube,
        DiscardLastCard,
        RunAway,
        GainTerror,
        LooseRep,
        LooseEnergy
    }

    public enum KeyValue
    {
        NoKey,
        EmptyKey,
        OneAtr,
        TwoAtr,
        OneMultiply,
        TwoMultiply,
        OneDamage,
        TwoDamage,
        Magic,
        BonusKey,
        DrawCard,
        DiscardLast,
        Void
    }

    public enum CardEffectType
    {
        EnemyHealsLess,
        PreventDamage,
        GainCharges,
        DrawCard,
    }

    public enum CardSet
    {
        BlueBaseCombat,
        GrayBaseCombat,
        GreenBaseCombat,
        BrownBaseCombat,
        BeorCombat,
        AileiCombat,
        MaggotCombat,
        ArevCombat,
        NiamhCombat,
        BlueBaseDiplomacy,
        GrayBaseDiplomacy,
        GreenBaseDiplomacy,
        BrownBaseDiplomacy,
        BeorDiplomacy,
        AileiDiplomacy,
        MaggotDiplomacy,
        ArevDiplomacy,
        NiamhDiplomacy,
    }

    public enum CharacterName
    {
        Beor,
        Ailei,
        Maggot,
        Arev,
        Niamh
    }

    public enum CharacterArchetype
    {
        Blue,
        Gray,
        Green,
        Brown
    }

    public enum LocationSetlementTypeEnum
    {
        None,
        FriendlySettlement,
        HostileSettlement,
    }

    public enum PlayerNumber
    {
        Player1,
        Player2,
        Player3,
        Player4
    }

    public enum ActionType
    {
        Explore,
        Travel,
        LocationAction,
        CharacterAction,
        InspectMenhir,
        Pass,
        Other
        //Items,Skills,Secrets
    }
}