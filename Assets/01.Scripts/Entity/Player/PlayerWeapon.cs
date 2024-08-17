using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField]
    private Animator _handAnimator;
    [field: SerializeField]
    public WeaponSO CurrentWeapon { get; private set; }
    public SquareDamageCaster DamageCasterCompo { get; private set; }

    [SerializeField] private ThrowingWeapon throwingWeaponPrefab;

    private Player _playerBase;
    
    private int _comboCounter = 0;
    private float _lastAttackTime = 0;
    private float _comboInitTime = 0.7f;
    private float _comboInitTimer = 0f;
    private float _attackDelay = 0.1f;
    private bool _isAttacking = false;
    private int _weaponDurability = 0;
    
    private readonly int _comboCounterHash = Animator.StringToHash("ComboCounter");
    private readonly int _attackBoolHash = Animator.StringToHash("Attack");

    private void Awake()
    {
        DamageCasterCompo = GetComponent<SquareDamageCaster>();
        _playerBase = GetComponent<Player>();
    }

    private void Update()
    {
        if (_isAttacking)
        {
            _comboInitTimer += Time.deltaTime;
            if (_comboInitTimer > _comboInitTime)
            {
                _handAnimator.SetBool(_attackBoolHash, false);
                _comboCounter = 0;
                _comboInitTimer = 0;
                _isAttacking = false;
            }
        }
    }

    public void SetWeapon(WeaponSO weaponSO)
    {
        CurrentWeapon = weaponSO;
        _handAnimator.runtimeAnimatorController = weaponSO.animatorController;
        var spriteRenderer = _handAnimator.GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = true;
        spriteRenderer.sprite = weaponSO.grabSprite;
        _weaponDurability = weaponSO.durability;
    }

    public void Attack()
    {
        if (!CurrentWeapon)
            return;

        if (!CurrentWeapon.attackAble)
        {
            Interaction();
            return;
        }
        
        if (_lastAttackTime + _attackDelay > Time.time) return;
        if (_lastAttackTime + _comboInitTime < Time.time || _comboCounter > 2)
            _comboCounter = 0;
        
        _comboInitTimer = 0;
        _isAttacking = true;
        _handAnimator.SetBool(_attackBoolHash, true);
        _handAnimator.SetInteger(_comboCounterHash, _comboCounter);
        _comboCounter++;
        //DamageCasterCompo.DamageCast(CurrentWeapon.attackRange[_comboCounter]); // �޺��� ���� �ٸ� ���� ����
        if (DamageCasterCompo.DamageCast(CurrentWeapon.attackRange[0], CurrentWeapon.swingDamage, out var targets))
        {
            foreach (Collider2D tar in targets)
            {
                BattleController.Inst.damageHudController.Generate(tar.gameObject, CurrentWeapon.swingDamage);
                Instantiate(CurrentWeapon.hitEffectPrefab, tar.transform.position,  Quaternion.Euler(0, 0, Random.Range(0, 360f)));
            }
            TimeController.Instance.SetTimeFreeze(0.5f, 0.1f, 0.2f);
            CameraManager.Instance.ShakeCamera(10, 0.3f);
            _weaponDurability--;
        }
        _lastAttackTime = Time.time;
        
        if (_weaponDurability <= 0)
        {
            RemoveWeapon();
        }
    }
    
    public void Interaction()
    {
        if (CurrentWeapon)
        {
            var weapon = Instantiate(throwingWeaponPrefab, transform.position, Quaternion.identity);
            print(CurrentWeapon);
            weapon.Initialize(CurrentWeapon, _playerBase.IsFacingRight ? Vector2.right : Vector2.left);
            RemoveWeapon();
        }
        else
        {
            _playerBase.NearestInteractableObj?.Interact(_playerBase);
        }
    }

    private void RemoveWeapon()
    {
        CurrentWeapon = null;
        _handAnimator.GetComponent<SpriteRenderer>().enabled = false;
        //터지는 효과
    }

}
