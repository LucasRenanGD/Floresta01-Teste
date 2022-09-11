public enum Team { Player, Enemy }
interface ICharacter
{
    Team Team { get; }
    void TakeDamage(int damage);
}