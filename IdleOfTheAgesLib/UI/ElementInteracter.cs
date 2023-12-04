// <copyright file="ElementInteracter.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using UnityEngine;
using UnityEngine.UIElements;

namespace IdleOfTheAgesLib.UI {
    /// <summary>
    /// Allows for interacting with an <see cref="Element"/>.
    /// </summary>
    /// <typeparam name="T">The type of the <see cref="Element"/> this interactor should interact with.</typeparam>
    public abstract class ElementInteracter<T> : PointerManipulator where T : Element {
        /// <summary>
        /// Gets the element we are interacting with.
        /// </summary>
        protected T Element => element;

        /// <summary>
        /// Gets the start position in world space of the element when dragging started.
        /// </summary>
        protected Vector3 TargetStartPosition { get; private set; }

        /// <summary>
        /// Gets the start position of the pointer in world space when dragging started.
        /// </summary>
        protected Vector3 PointerStartPosition { get; private set; }

        /// <summary>
        /// Gets the position of the pointer at the previous frame.
        /// </summary>
        protected Vector3 PointerPreviousPosition { get; private set; }

        /// <summary>
        /// Gets the change in pointer position from when the dragging started.
        /// </summary>
        protected Vector3 PointerStartDelta { get; private set; }

        /// <summary>
        /// Gets the change in pointer position from the last frame.
        /// </summary>
        protected Vector3 PointerFrameDelta { get; private set; }

        private readonly T element;
        private bool enabled;

        /// <summary>
        /// Initializes a new instance of the <see cref="ElementInteracter{T}"/> class.
        /// </summary>
        /// <param name="target">The element we interact with.</param>
        protected ElementInteracter(T target) {
            element = target;
            target.ApplyManipulator(this);
        }

        /// <inheritdoc/>
        protected override void RegisterCallbacksOnTarget() {
            target.RegisterCallback<PointerDownEvent>(PointerDownHandler);
            target.RegisterCallback<PointerMoveEvent>(PointerMoveHandler);
            target.RegisterCallback<PointerUpEvent>(PointerUpHandler);
        }

        /// <inheritdoc/>
        protected override void UnregisterCallbacksFromTarget() {
            target.UnregisterCallback<PointerDownEvent>(PointerDownHandler);
            target.UnregisterCallback<PointerMoveEvent>(PointerMoveHandler);
            target.UnregisterCallback<PointerUpEvent>(PointerUpHandler);
        }

        /// <summary>
        /// Called when dragging starts.
        /// </summary>
        /// <param name="args">The arguments of the event.</param>
        protected virtual void OnPointerDown(PointerDownEvent args) { }

        /// <summary>
        /// Called when the pointer moves while dragging.
        /// </summary>
        /// <param name="args">The arguments of the event.</param>
        protected virtual void OnPointerMove(PointerMoveEvent args) { }

        /// <summary>
        /// Called when dragging ends.
        /// </summary>
        /// <param name="args">The arguments of the event.</param>
        protected virtual void OnPointerUp(PointerUpEvent args) { }

        private void PointerDownHandler(PointerDownEvent args) {
            TargetStartPosition = target.transform.position;
            PointerStartPosition = args.position;
            PointerPreviousPosition = PointerStartPosition;
            target.CapturePointer(args.pointerId);
            enabled = true;

            OnPointerDown(args);
        }

        private void PointerMoveHandler(PointerMoveEvent args) {
            if (!enabled)
                return;

            if (target.HasPointerCapture(args.pointerId)) {
                PointerStartDelta = args.position - PointerStartPosition;
                PointerFrameDelta = args.position - PointerPreviousPosition;

                OnPointerMove(args);

                PointerPreviousPosition = args.position;
            }
        }

        private void PointerUpHandler(PointerUpEvent args) {
            if (!enabled)
                return;

            if (target.HasPointerCapture(args.pointerId)) {
                target.ReleasePointer(args.pointerId);
                OnPointerUp(args);
            }
        }
    }
}
