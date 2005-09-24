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

public class DcmLongText : DcmCharString {
  private IntPtr swigCPtr;

  internal DcmLongText(IntPtr cPtr, bool cMemoryOwn) : base(DCMTKPINVOKE.DcmLongTextUpcast(cPtr), cMemoryOwn) {
    swigCPtr = cPtr;
  }

  internal static IntPtr getCPtr(DcmLongText obj) {
    return (obj == null) ? IntPtr.Zero : obj.swigCPtr;
  }

  protected DcmLongText() : this(IntPtr.Zero, false) {
  }

  ~DcmLongText() {
    Dispose();
  }

  public override void Dispose() {
    if(swigCPtr != IntPtr.Zero && swigCMemOwn) {
      swigCMemOwn = false;
      DCMTKPINVOKE.delete_DcmLongText(swigCPtr);
    }
    swigCPtr = IntPtr.Zero;
    GC.SuppressFinalize(this);
    base.Dispose();
  }

  public DcmLongText(DcmTag tag, uint len) : this(DCMTKPINVOKE.new_DcmLongText__SWIG_0(DcmTag.getCPtr(tag), len), true) {
  }

  public DcmLongText(DcmTag tag) : this(DCMTKPINVOKE.new_DcmLongText__SWIG_1(DcmTag.getCPtr(tag)), true) {
  }

  public DcmLongText(DcmLongText old) : this(DCMTKPINVOKE.new_DcmLongText__SWIG_2(DcmLongText.getCPtr(old)), true) {
  }

  public override DcmEVR ident() {
    return (DcmEVR)DCMTKPINVOKE.DcmLongText_ident(swigCPtr);
  }

  public override uint getVM() {
    return DCMTKPINVOKE.DcmLongText_getVM(swigCPtr);
  }

  public override OFCondition getOFString(StringBuilder stringVal, uint pos, bool normalize) {
    return new OFCondition(DCMTKPINVOKE.DcmLongText_getOFString__SWIG_0(swigCPtr, stringVal, pos, normalize), true);
  }

  public override OFCondition getOFString(StringBuilder stringVal, uint pos) {
    return new OFCondition(DCMTKPINVOKE.DcmLongText_getOFString__SWIG_1(swigCPtr, stringVal, pos), true);
  }

  public override OFCondition getOFStringArray(StringBuilder stringVal, bool normalize) {
    return new OFCondition(DCMTKPINVOKE.DcmLongText_getOFStringArray__SWIG_0(swigCPtr, stringVal, normalize), true);
  }

  public override OFCondition getOFStringArray(StringBuilder stringVal) {
    return new OFCondition(DCMTKPINVOKE.DcmLongText_getOFStringArray__SWIG_1(swigCPtr, stringVal), true);
  }

}

}
