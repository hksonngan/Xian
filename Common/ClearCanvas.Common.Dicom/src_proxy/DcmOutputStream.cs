/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 1.3.24
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */

namespace ClearCanvas.Common.DICOM {

using System;
using System.Text;

public class DcmOutputStream : IDisposable {
  private IntPtr swigCPtr;
  protected bool swigCMemOwn;

  internal DcmOutputStream(IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = cPtr;
  }

  internal static IntPtr getCPtr(DcmOutputStream obj) {
    return (obj == null) ? IntPtr.Zero : obj.swigCPtr;
  }

  protected DcmOutputStream() : this(IntPtr.Zero, false) {
  }

  ~DcmOutputStream() {
    Dispose();
  }

  public virtual void Dispose() {
    if(swigCPtr != IntPtr.Zero && swigCMemOwn) {
      swigCMemOwn = false;
      DCMTKPINVOKE.delete_DcmOutputStream(swigCPtr);
    }
    swigCPtr = IntPtr.Zero;
    GC.SuppressFinalize(this);
  }

  public virtual bool good() {
    return DCMTKPINVOKE.DcmOutputStream_good(swigCPtr);
  }

  public virtual OFCondition status() {
    return new OFCondition(DCMTKPINVOKE.DcmOutputStream_status(swigCPtr), true);
  }

  public virtual bool isFlushed() {
    return DCMTKPINVOKE.DcmOutputStream_isFlushed(swigCPtr);
  }

  public virtual uint avail() {
    return DCMTKPINVOKE.DcmOutputStream_avail(swigCPtr);
  }

  public virtual uint write(SWIGTYPE_p_void buf, uint buflen) {
    return DCMTKPINVOKE.DcmOutputStream_write(swigCPtr, SWIGTYPE_p_void.getCPtr(buf), buflen);
  }

  public virtual void flush() {
    DCMTKPINVOKE.DcmOutputStream_flush(swigCPtr);
  }

  public virtual uint tell() {
    return DCMTKPINVOKE.DcmOutputStream_tell(swigCPtr);
  }

  public virtual OFCondition installCompressionFilter(E_StreamCompression filterType) {
    return new OFCondition(DCMTKPINVOKE.DcmOutputStream_installCompressionFilter(swigCPtr, (int)filterType), true);
  }

}

}
