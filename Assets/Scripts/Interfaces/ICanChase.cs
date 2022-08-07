using UnityEngine;
using UnityEngine.AI;

namespace Interfaces
{
   public interface ICanChase
   {
      public NavMeshAgent Agent { get; }
      public Transform Target { get; }
      public float Distance { get; set; }
   }
}
