using System;
using System.Collections.Generic;

public class FacialFeatures
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }

    public override bool Equals(object obj)
    {
        if (obj is FacialFeatures other)
        {
            return EyeColor == other.EyeColor && PhiltrumWidth == other.PhiltrumWidth;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(EyeColor, PhiltrumWidth);
    }
}

public class Identity
{
    public string Email { get; }
    public FacialFeatures FacialFeatures { get; }

    public Identity(string email, FacialFeatures facialFeatures)
    {
        Email = email;
        FacialFeatures = facialFeatures;
    }

    public override bool Equals(object obj)
    {
        if (obj is Identity other)
        {
            return Email == other.Email && Equals(FacialFeatures, other.FacialFeatures);
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Email, FacialFeatures);
    }
}

public class Authenticator
{
    private readonly HashSet<Identity> _registeredIdentities = new HashSet<Identity>();

    // Tarea 1: Comprobar si dos rostros son iguales
    public static bool AreSameFace(FacialFeatures face1, FacialFeatures face2)
    {
        if (face1 == null) return face2 == null;
        return face1.Equals(face2);
    }

    // Tarea 2: Comprobar si la identidad coincide con la del administrador
    public bool IsAdmin(Identity identity)
    {
        var adminIdentity = new Identity("admin@exerc.ism", new FacialFeatures("green", 0.9m));
        return adminIdentity.Equals(identity);
    }

    // Tarea 3: Registrar una identidad (devuelve false si ya estaba registrada)
    public bool Register(Identity identity)
    {
        return _registeredIdentities.Add(identity);
    }

    // Tarea 4: Comprobar si una identidad está registrada
    public bool IsRegistered(Identity identity)
    {
        return _registeredIdentities.Contains(identity);
    }

    public static bool AreSameObject(object objectA, object objectB)
    {
        return ReferenceEquals(objectA, objectB);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var authenticator = new Authenticator();

        Console.WriteLine("=== Tarea 1: AreSameFace ===");
        var face1 = new FacialFeatures("green", 0.9m);
        var face2 = new FacialFeatures("green", 0.9m);
        var face3 = new FacialFeatures("blue", 0.9m);

        Console.WriteLine($"¿face1 y face2 son iguales?: {Authenticator.AreSameFace(face1, face2)} (Esperado: True)");
        Console.WriteLine($"¿face1 y face3 son iguales?: {Authenticator.AreSameFace(face1, face3)} (Esperado: False)");

        Console.WriteLine("\n=== Tarea 2: IsAdmin ===");
        var admin = new Identity("admin@exerc.ism", new FacialFeatures("green", 0.9m));
        var nonAdmin = new Identity("admin@thecompetition.com", new FacialFeatures("green", 0.9m));

        Console.WriteLine($"¿Es Admin admin?: {authenticator.IsAdmin(admin)} (Esperado: True)");
        Console.WriteLine($"¿Es Admin nonAdmin?: {authenticator.IsAdmin(nonAdmin)} (Esperado: False)");

        Console.WriteLine("\n=== Tarea 3 y 4: Register e IsRegistered ===");
        var user1 = new Identity("tunde@thecompetition.com", new FacialFeatures("blue", 0.9m));
        var user2 = new Identity("alice@thecompetition.com", new FacialFeatures("blue", 0.8m));

        Console.WriteLine($"¿user2 está registrado inicialmente?: {authenticator.IsRegistered(user2)} (Esperado: False)");
        Console.WriteLine($"Primer registro de user1: {authenticator.Register(user1)} (Esperado: True)");
        Console.WriteLine($"¿user1 está registrado?: {authenticator.IsRegistered(user1)} (Esperado: True)");
        Console.WriteLine($"Segundo registro de user1 (duplicado): {authenticator.Register(user1)} (Esperado: False)");

        Console.WriteLine("\n=== Tarea 5: AreSameObject (Igualdad de Referencia) ===");
        var identityA = new Identity("alice@thecompetition.com", new FacialFeatures("blue", 0.9m));
        var identityB = identityA; // Apuntan a la misma instancia
        var identityC = new Identity("alice@thecompetition.com", new FacialFeatures("blue", 0.9m)); // Nueva instancia con mismos valores

        Console.WriteLine($"¿identityA e identityB son el mismo objeto?: {Authenticator.AreSameObject(identityA, identityB)} (Esperado: True)");
        Console.WriteLine($"¿identityC e identityD son el mismo objeto?: {Authenticator.AreSameObject(identityA, identityC)} (Esperado: False)");
    }
}
