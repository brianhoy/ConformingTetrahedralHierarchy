using System.Collections.Generic;
using System.Collections.Concurrent;
using UnityEngine;

namespace DMC {
	public class Node {
		public Node[] Children;
		public Vector3[] Vertices; // used for everything else (consistent clockwise ordering)
		public Vector3[] HVertices; // used for splitting tetrahedrons
		public Vector3 Center;
		public Vector3 CentralVertex; // midpoint of longest edge, center of bounding sphere
		public float BoundRadius; // half of longest edge length
		public int TetrahedronType;
		public int Depth; // 0 indicates top-level tetrahedron
		public uint Number; // used as UID system
		public bool IsLeaf;
		public bool ReversedWindingOrder;
		public GameObject UnityObject;
		public Node Parent;
		public Sphere BoundingSphere;
	}

	public class Root {
		public Node[] Children;
		public Dictionary<uint, Node> Nodes; // Index: Node number | Value: Node
		public Dictionary<Vector3, ConcurrentBag<Node>> FaceToNodeList; // Index: Centroid of face | Value: All nodes sharing that face
		public bool IsValid; // true if every split uses the longest edge
	}

	public class Hexahedron {
		public Vector3[] Vertices; // 8
		public Face[] BaseFaces;
		public Hexahedron[] Children;
		public bool IsLeaf;
	}
	public class Face {
		public Vector3 Centroid;
		public Vector3[] Vertices;
	}
	public class MCBarycentricUnit {
		public Vector4[] BarycentricCoords;
	}
	public class MCCartesianUnit {
		public Vector3[] CartesianCoords;
		public float[] Values;
	}
	public class AdaptResult {
		public Node[] SplitList;
		public int SplitListLength;
		public Node[] CoarsenList;
		public int CoarsenListLength;
	}
}