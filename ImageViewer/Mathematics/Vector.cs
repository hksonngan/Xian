#region License

// Copyright (c) 2010, ClearCanvas Inc.
// All rights reserved.
// http://www.clearcanvas.ca
//
// This software is licensed under the Open Software License v3.0.
// For the complete license, see http://www.clearcanvas.ca/OSLv3.0

#endregion

using System;
using System.Drawing;

namespace ClearCanvas.ImageViewer.Mathematics
{
	/// <summary>
	/// A collection vector related methods.
	/// </summary>
	public static class Vector
	{
		/// <summary>
		/// Calculates the angle subtended by two line segments that meet at a vertex.
		/// </summary>
		/// <param name="start">The end of one of the line segments.</param>
		/// <param name="vertex">The vertex of the angle formed by the two line segments.</param>
		/// <param name="end">The end of the other line segment.</param>
		/// <returns>The angle subtended by the two line segments in degrees.</returns>
		public static double SubtendedAngle(PointF start, PointF vertex, PointF end)
		{
			Vector3D vertexPositionVector = new Vector3D(vertex.X, vertex.Y, 0);
			Vector3D a = new Vector3D(start.X, start.Y, 0) - vertexPositionVector;
			Vector3D b = new Vector3D(end.X, end.Y, 0) - vertexPositionVector;

			float dotProduct = a.Dot(b);

			Vector3D crossProduct = a.Cross(b);

			float magA = a.Magnitude;
			float magB = b.Magnitude;

			if (FloatComparer.AreEqual(magA, 0F) || FloatComparer.AreEqual(magB, 0F))
				return 0;

			double cosTheta = dotProduct/magA/magB;

			// Make sure cosTheta is within bounds so we don't
			// get any errors when we take the acos.
			if (cosTheta > 1.0f)
				cosTheta = 1.0f;

			if (cosTheta < -1.0f)
				cosTheta = -1.0f;

			double theta = Math.Acos(cosTheta)*(crossProduct.Z == 0 ? 1 : -Math.Sign(crossProduct.Z));
			double thetaInDegrees = theta/Math.PI*180;

			return thetaInDegrees;
		}

		/// <summary>
		/// Calculates the distance between two points.
		/// </summary>
		/// <param name="pt1">One end of the distance to be computed.</param>
		/// <param name="pt2">The other end of the distance to be computed.</param>
		/// <returns>The distance between the two points.</returns>
		public static double Distance(PointF pt1, PointF pt2)
		{
			float deltaX = pt2.X - pt1.X;
			float deltaY = pt2.Y - pt1.Y;

			return Math.Sqrt(deltaX*deltaX + deltaY*deltaY);
		}

		/// <summary>
		/// Finds the midpoint between two points.
		/// </summary>
		/// <param name="pt1">One end of the span.</param>
		/// <param name="pt2">The other end of the span.</param>
		/// <returns>The midpoint between the two points.</returns>
		public static PointF Midpoint(PointF pt1, PointF pt2)
		{
			float x = (pt1.X + pt2.X)/2f;
			float y = (pt1.Y + pt2.Y)/2f;

			return new PointF(x, y);
		}

		/// <summary>
		/// Computes the unit vector of the vector defined by <paramref name="vector"/>.
		/// </summary>
		/// <param name="vector">The vector given as a point relative to the origin.</param>
		/// <returns>The unit vector in the same direction as the given vector.</returns>
		/// <exception cref="ArgumentException">If <paramref name="vector"/> is equal to the origin.</exception>
		public static PointF CreateUnitVector(PointF vector)
		{
			if (FloatComparer.AreEqual(PointF.Empty, vector))
				throw new ArgumentException("Argument must specify a valid vector.", "vector");
			return CreateUnitVector(PointF.Empty, vector);
		}

		/// <summary>
		/// Computes the unit vector of the vector defined by <paramref name="startingPoint"/> to <paramref name="endingPoint"/>.
		/// </summary>
		/// <param name="startingPoint">The starting point of the vector.</param>
		/// <param name="endingPoint">The ending point of the vector.</param>
		/// <returns>The unit vector in the same direction as the given vector.</returns>
		/// <exception cref="ArgumentException">If <paramref name="startingPoint"/> is equal to <paramref name="endingPoint"/>.</exception>
		public static PointF CreateUnitVector(PointF startingPoint, PointF endingPoint)
		{
			if (FloatComparer.AreEqual(startingPoint, endingPoint))
				throw new ArgumentException("Arguments must specify a valid vector.", "endingPoint");
			float deltaX = endingPoint.X - startingPoint.X;
			float deltaY = endingPoint.Y - startingPoint.Y;
			double magnitude = Math.Sqrt(deltaX*deltaX + deltaY*deltaY);
			return new PointF((float) (deltaX/magnitude), (float) (deltaY/magnitude));
		}

		/// <summary>
		/// Calculates the shortest distance from a point to a line segment.
		/// </summary>
		/// <param name="ptTest">Point to be tested.</param>
		/// <param name="pt1">One end of the line segment.</param>
		/// <param name="pt2">The other end of the line segement.</param>
		/// <param name="ptNearest">Returns the point on the line segment nearest to the <paramref name="ptTest">test point</paramref>.</param>
		/// <returns>The distance from the <paramref name="ptTest">test point</paramref> to the <paramref name="ptNearest">nearest point</paramref> on the line segment.</returns>
		public static double DistanceFromPointToLine(PointF ptTest, PointF pt1, PointF pt2, ref PointF ptNearest)
		{
			float distanceX;
			float distanceY;
			double distance;

			// Point on line segment nearest to pt0
			float dx = pt2.X - pt1.X;
			float dy = pt2.Y - pt1.Y;

			// It's a point, not a line
			if (dx == 0 && dy == 0)
			{
				ptNearest.X = pt1.X;
				ptNearest.Y = pt1.Y;
			}
			else
			{
				// Parameter
				double t = ((ptTest.X - pt1.X)*dx + (ptTest.Y - pt1.Y)*dy)/(double) (dx*dx + dy*dy);

				// Nearest point is pt1
				if (t < 0)
				{
					ptNearest = pt1;
				}
					// Nearest point is pt2
				else if (t > 1)
				{
					ptNearest = pt2;
				}
					// Nearest point is on the line segment
				else
				{
					// Parametric equation
					ptNearest.X = (float) (pt1.X + t*dx);
					ptNearest.Y = (float) (pt1.Y + t*dy);
				}
			}

			distanceX = ptTest.X - ptNearest.X;
			distanceY = ptTest.Y - ptNearest.Y;
			distance = Math.Sqrt(distanceX*distanceX + distanceY*distanceY);

			return distance;
		}

		/// <summary>
		/// Possible arrangements of two line segments.
		/// </summary>
		public enum LineSegments
		{
			/// <summary>
			/// The line segments do not interesect.
			/// </summary>
			DoNotIntersect,
			/// <summary>
			/// The line segments intersect.
			/// </summary>
			Intersect,
			/// <summary>
			/// The line segments are colinear.
			/// </summary>
			Colinear
		}

		/// <summary>
		/// Determines whether two line segments intersect, do not intersect or are colinear.
		/// </summary>
		/// <remarks>
		/// This function used to perform unwarranted rounding of the intersection point.
		/// It has now been rewritten to take advantage of <see cref="IntersectLineSegments"/> and
		/// <see cref="AreColinear"/>, which do not perform any automatic rounding of the intersection.
		/// </remarks>
		/// <param name="p1">One endpoint of one line segment.</param>
		/// <param name="p2">The other endpoint of one line segment.</param>
		/// <param name="q1">One endpoint of the other line segment.</param>
		/// <param name="q2">The other endpoint of the other line segment.</param>
		/// <param name="intersectionPoint">The intersection between the two line segments, if a solution exists.</param>
		/// <returns>A value indicating whether the two line segments are colinear, intersect, or do not intersect.</returns>
		[Obsolete("This function has been deprecated in favour of IntersectLineSegments and AreColinear.")]
		public static LineSegments LineSegmentIntersection(PointF p1, PointF p2, PointF q1, PointF q2, out PointF intersectionPoint)
		{
			intersectionPoint = PointF.Empty;
			if (AreColinear(p1, p2, q1, q2))
				return LineSegments.Colinear;
			return IntersectLineSegments(p1, p2, q1, q2, out intersectionPoint) ? LineSegments.Intersect : LineSegments.DoNotIntersect;
		}

		/// <summary>
		/// Computes the intersection between two line segments, if a solution exists.
		/// </summary>
		/// <param name="p1">One endpoint of one line segment.</param>
		/// <param name="p2">The other endpoint of one line segment.</param>
		/// <param name="q1">One endpoint of the other line segment.</param>
		/// <param name="q2">The other endpoint of the other line segment.</param>
		/// <param name="intersection">The intersection between the two line segments, if a solution exists.</param>
		/// <returns>True if the intersection exists; False otherwise.</returns>
		public static bool IntersectLineSegments(PointF p1, PointF p2, PointF q1, PointF q2, out PointF intersection)
		{
			// find the solution to the line equations in matrix form
			// P1 + s(P2-P1) = Q1 + t(Q2-Q1)
			// => P1 + s(P2-P1) = Q1 - t(Q1-Q2)
			// => [P2-P1 Q1-Q2] * [s t]^T = Q1-P1
			// => [s t]^T = [P2-P1 Q1-Q2]^-1 * [Q1-P1]

			// compute elements of the matrix M
			var m11 = p2.X - p1.X; // M[R1C1]
			var m12 = q1.X - q2.X; // M[R1C2]
			var m21 = p2.Y - p1.Y; // M[R2C1]
			var m22 = q1.Y - q2.Y; // M[R2C2]

			// compute determinant of the matrix M
			var determinant = m11*m22 - m12*m21; // det(M)
			if (!FloatComparer.AreEqual(determinant, 0))
			{
				// compute elements of the inverted matrix M^-1
				var v11 = m22/determinant;
				var v12 = -m12/determinant;
				var v21 = -m21/determinant;
				var v22 = m11/determinant;

				// compute elements of the RHS vector
				var r1 = q1.X - p1.X;
				var r2 = q1.Y - p1.Y;

				// left-multiply inverted matrix with RHS to get solution of {s,t}
				var s = v11*r1 + v12*r2;
				var t = v21*r1 + v22*r2;

				// the solution {s,t} represents the intersection of the lines
				// for line segments, we must therefore further restrict the valid range of {s,t} to [0,1]
				const int tolerance = 100000; // allow additional tolerance due to amount of floating-point computation
				if (FloatComparer.Compare(s, 0, tolerance) >= 0 && FloatComparer.Compare(s, 1, tolerance) <= 0
				    && FloatComparer.Compare(t, 0, tolerance) >= 0 && FloatComparer.Compare(t, 1, tolerance) <= 0)
				{
					intersection = new PointF(p1.X + s*m11, p1.Y + s*m21);
					return true;
				}
			}

			intersection = PointF.Empty;
			return false;
		}

		/// <summary>
		/// Computes the intersection between two lines, if a solution exists.
		/// </summary>
		/// <param name="p1">One endpoint of one line.</param>
		/// <param name="p2">The other endpoint of one line.</param>
		/// <param name="q1">One endpoint of the other line.</param>
		/// <param name="q2">The other endpoint of the other line.</param>
		/// <param name="intersection">The intersection between the two lines, if a solution exists.</param>
		/// <returns>True if the intersection exists and is distinct; False otherwise.</returns>
		public static bool IntersectLines(PointF p1, PointF p2, PointF q1, PointF q2, out PointF intersection)
		{
			// find the solution to the line equations in matrix form
			// P1 + s(P2-P1) = Q1 + t(Q2-Q1)
			// => P1 + s(P2-P1) = Q1 - t(Q1-Q2)
			// => [P2-P1 Q1-Q2] * [s t]^T = Q1-P1
			// => [s t]^T = [P2-P1 Q1-Q2]^-1 * [Q1-P1]

			// compute elements of the matrix M
			var m11 = p2.X - p1.X; // M[R1C1]
			var m12 = q1.X - q2.X; // M[R1C2]
			var m21 = p2.Y - p1.Y; // M[R2C1]
			var m22 = q1.Y - q2.Y; // M[R2C2]

			// compute determinant of the matrix M
			var determinant = m11*m22 - m12*m21; // det(M)
			if (!FloatComparer.AreEqual(determinant, 0))
			{
				// compute elements of the inverted matrix M^-1
				var v11 = m22/determinant;
				var v12 = -m12/determinant;
				// var v21 = -m21/determinant;
				// var v22 = m11/determinant;

				// compute elements of the RHS vector
				var r1 = q1.X - p1.X;
				var r2 = q1.Y - p1.Y;

				// left-multiply inverted matrix with RHS to get solution of {s,t}
				var s = v11*r1 + v12*r2;
				// var t = v21*r1 + v22*r2;

				// the solution {s,t} represents the intersection of the lines
				intersection = new PointF(p1.X + s*m11, p1.Y + s*m21);
				return true;
			}

			intersection = PointF.Empty;
			return false;
		}

		/// <summary>
		/// Determines whether or not two lines are parallel.
		/// </summary>
		/// <param name="p1">One endpoint of one line.</param>
		/// <param name="p2">The other endpoint of one line.</param>
		/// <param name="q1">One endpoint of the other line.</param>
		/// <param name="q2">The other endpoint of the other line.</param>
		/// <returns>True if the lines are parallel; False otherwise.</returns>
		public static bool AreParallel(PointF p1, PointF p2, PointF q1, PointF q2)
		{
			// find the solution to the line equations in matrix form
			// P1 + s(P2-P1) = Q1 + t(Q2-Q1)
			// => P1 + s(P2-P1) = Q1 - t(Q1-Q2)
			// => [P2-P1 Q1-Q2] * [s t]^T = Q1-P1
			// => [s t]^T = [P2-P1 Q1-Q2]^-1 * [Q1-P1]

			// compute elements of the matrix M
			var m11 = p2.X - p1.X; // M[R1C1]
			var m12 = q1.X - q2.X; // M[R1C2]
			var m21 = p2.Y - p1.Y; // M[R2C1]
			var m22 = q1.Y - q2.Y; // M[R2C2]

			// compute determinant of the matrix M
			var determinant = m11*m22 - m12*m21; // det(M)

			// if a distinct solution does not exist then the lines must be parallel
			return FloatComparer.AreEqual(determinant, 0);
		}

		/// <summary>
		/// Determines whether or not two lines are colinear.
		/// </summary>
		/// <remarks>
		/// Colinearity here is defined as whether or not you can draw a single line through all given points.
		/// This definition is used because it explicitly provides for classification of degenerate cases
		/// where one or both &quot;lines&quot; are actually coincident points.
		/// </remarks>
		/// <param name="p1">One endpoint of one line.</param>
		/// <param name="p2">The other endpoint of one line.</param>
		/// <param name="q1">One endpoint of the other line.</param>
		/// <param name="q2">The other endpoint of the other line.</param>
		/// <returns>True if the lines are colinear; False otherwise.</returns>
		public static bool AreColinear(PointF p1, PointF p2, PointF q1, PointF q2)
		{
			// colinearity test algorithm:
			// 1. compute vectors from one endpoint to each of the other three endpoints
			// 2. if all three vectors are trivial (i.e. zero) then all endpoints are coincident and thus "colinear"
			// 3. otherwise they are colinear iff the non-trivial vector is (anti-)parallel to the other two vectors (as they have a common point)
			// to test for parallel vectors while ignoring direction, compute the dot product between one vector and a perpendicular to the other vector.

			// compute the vectors from P1 to each of P2, Q1 and Q2
			var vector0 = p1 - new SizeF(p2);
			var vector1 = p1 - new SizeF(q1);
			var vector2 = p1 - new SizeF(q2);

			// make sure we have the non-trivial vector in vector0
			if (FloatComparer.AreEqual(PointF.Empty, vector0))
			{
				if (FloatComparer.AreEqual(PointF.Empty, vector1))
				{
					// if both P1P2 and P1Q1 are trivial, then we have at most two distinct points, through which you can always draw a line!
					return true;
				}
				else
				{
					// vector1 is non-trivial and vector0 is trivial, so swap them
					var temp = vector0;
					vector0 = vector1;
					vector1 = temp;
				}
			}

			// lines are colinear iff the other two vectors are parallel to the non-trivial vector
			return FloatComparer.AreEqual(vector0.Y*vector1.X - vector0.X*vector1.Y, 0) && FloatComparer.AreEqual(vector0.Y*vector2.X - vector0.X*vector2.Y, 0);
		}

		/// <summary>
		/// Computes the difference between two points as a delta offset.
		/// </summary>
		/// <param name="previousPosition">The point from which the offset is to be computed.</param>
		/// <param name="currentPosition">The point to which the offset is to be computed.</param>
		/// <returns>The offset to get from <paramref name="previousPosition"/> to <paramref name="currentPosition"/>.</returns>
		public static SizeF CalculatePositionDelta(PointF previousPosition, PointF currentPosition)
		{
			float deltaX = currentPosition.X - previousPosition.X;
			float deltaY = currentPosition.Y - previousPosition.Y;

			return new SizeF(deltaX, deltaY);
		}
	}
}